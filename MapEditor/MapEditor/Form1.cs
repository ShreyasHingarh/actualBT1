using MapEditor.Properties;

using Microsoft.VisualBasic.Devices;

using System.Numerics;
using System.Security.Policy;
using Newtonsoft.Json;

namespace MapEditor
{

    public partial class Form1 : Form
    {
        public Square[,] Grasses;
        public Image ImageToDraw;
        public List<byte> ImageValues;
        public Square Start;
        public Square End;
        public int SizeFactor = 30;
        public int ScreenSize = 810;
        bool HaveDrawnStart;
        bool HaveDrawnEnd;
        AStar Graph;
        Draw TypeOfOneToDraw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graph = new AStar();

            ImageValues = new List<byte>();
            HaveDrawnStart = false;
            HaveDrawnEnd = false;
            int x = SizeFactor;
            int y = SizeFactor;
            Grasses = new Square[(ScreenSize / x), (ScreenSize / y)];
            x = 0;
            y = 0;
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    Grasses[i, z] = new Square();
                    ;
                    Grasses[i, z].Picture.Image = Resources.Grass;
                    Grasses[i, z].Picture.Location = new Point(x, y);
                    Grasses[i, z].Picture.Size = new Size(Resources.Grass.Width, Resources.Grass.Height);
                    Grasses[i, z].Picture.Visible = true;
                    Grasses[i, z].Type = Draw.Eraser;
                    x += SizeFactor;
                    Controls.Add(Grasses[i, z].Picture);
                }
                y += SizeFactor;
                x = 0;
            }
            ImageToDraw = Resources.Grass;
            TypeOfOneToDraw = Draw.Eraser;
            //AddAllVertices
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    Graph.AddVertex(Grasses[i, z]);
                }
            }
        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            ImageToDraw = Resources.Grass;
            TypeOfOneToDraw = Draw.Eraser;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            //\\GMRDC1\Folder Redirection\shreyas.hingarh\Documents\Github\ActualBT1\MapEditor\MapEditor\TextFile1.txt
            //C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\MapEditor\MapEditor\TextFile1.txt
            ImageValues = JsonConvert.DeserializeObject<List<byte>>(File.ReadAllText(@"\\GMRDC1\Folder Redirection\shreyas.hingarh\Documents\Github\ActualBT1\MapEditor\MapEditor\TextFile1.txt"));
            int index = 0;
            foreach(var item in Grasses)
            {
                switch (ImageValues[index])
                {
                    case 0:
                        item.Picture.Image = Resources.Grass;
                        item.Type = Draw.Eraser;
                        break;
                    case 1:
                        item.Picture.Image = Resources.Startx;
                        item.Type = Draw.Start;
                        HaveDrawnStart = true;
                        Start = item;
                        break;
                    case 2:
                        item.Picture.Image = Resources.Endx;
                        item.Type = Draw.End;
                        HaveDrawnEnd = true;
                        End = item;
                        break;
                    case 3:
                        item.Picture.Image = Resources.Path;
                        item.Type = Draw.Path;
                        break;
                }
                index++;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ImageValues.Clear();
            foreach(var item in Grasses)
            {
                switch (item.Type)
                {
                    case Draw.Eraser:
                        ImageValues.Add(0);
                        break;
                    case Draw.Start:
                        ImageValues.Add(1);
                        break;
                    case Draw.End:
                        ImageValues.Add(2);
                        break;
                    case Draw.Path:
                        ImageValues.Add(3);
                        break;
                    default:
                        return;
                }
            }
            string x = JsonConvert.SerializeObject(ImageValues);
            File.WriteAllText(@"\\GMRDC1\Folder Redirection\shreyas.hingarh\Documents\Github\ActualBT1\MapEditor\MapEditor\TextFile1.txt", x);
        }

        private void StartPath_Click(object sender, EventArgs e)
        {
            ImageToDraw = Resources.Startx;
            TypeOfOneToDraw = Draw.Start;
        }

        private void PathPicture_Click(object sender, EventArgs e)
        {
            ImageToDraw = Resources.Path;
            TypeOfOneToDraw = Draw.Path;
        }

        private void EndPath_Click(object sender, EventArgs e)
        {
            ImageToDraw = Resources.Endx;
            TypeOfOneToDraw = Draw.End;
        }
        public Point GetNearestLocation(Point Location)
        {
            Point point = new Point();
            int x = 0;
            while (x < ScreenSize)
            {
                if (Location.X >= x && Location.X < x + SizeFactor)
                {
                    point.X = x;
                    break;
                }
                x += SizeFactor;
            }
            int y = 0;
            while (y < ScreenSize)
            {
                if (Location.Y >= y && Location.Y < y + SizeFactor)
                {
                    point.Y = y;
                    break;
                }
                y += SizeFactor;
            }
            return point;
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            Rectangle mouse = new Rectangle(PointToClient(Cursor.Position), new Size(0, 0));
            Rectangle BoundryForScreen = new Rectangle(TheScreen.Location, TheScreen.Size);
            if (BoundryForScreen.Contains(mouse) && MouseButtons == MouseButtons.Left)
            {
                Point temp = GetNearestLocation(mouse.Location);
                switch (TypeOfOneToDraw)
                {
                    case Draw.Eraser:
                        if (Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.Start)
                        {
                            Start = null;
                            HaveDrawnStart = false;
                        }
                        if (Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.End)
                        {
                            End = null;
                            HaveDrawnEnd = false;
                        }
                        break;
                    case Draw.Start:
                        if (HaveDrawnStart) return;
                        if (!HaveDrawnStart)
                        {
                            Start = Grasses[temp.Y / SizeFactor, temp.X / SizeFactor];
                            HaveDrawnStart = true;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Image = ImageToDraw;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type = Draw.Start;
                            return;
                        }
                        break;
                    case Draw.End:
                        if (HaveDrawnEnd) return;
                        if (!HaveDrawnEnd)
                        {
                            End = Grasses[temp.Y / SizeFactor, temp.X / SizeFactor];
                            HaveDrawnEnd = true;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Image = ImageToDraw;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type = Draw.End;
                            return;
                        }
                        break;
                }
                if ((Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.End || Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.Start) && TypeOfOneToDraw == Draw.Path) return;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Image = ImageToDraw;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type = TypeOfOneToDraw;
            }
        }
        public void Checks(ref Square curNeighbor, ref List<Square> walls, ref Stack<Square> stack, ref List<Square> HaveAlreadyVisited)
        {
            if(!HaveAlreadyVisited.Contains(curNeighbor))
            {
                if (curNeighbor.Type == Draw.Eraser && !walls.Contains(curNeighbor))
                {
                    curNeighbor.IsWall = true;
                    walls.Add(curNeighbor);
                }
                else if(curNeighbor.Type != Draw.Eraser)
                {
                    stack.Push(curNeighbor);
                }
            }
        }
        public List<Square> GetWalls()
        {
            List<Square> HaveAlreadyVisited= new List<Square>();
            List<Square> walls = new List<Square>();
            if (Start == null || End == null) return null;
            int iX = Start.Picture.Location.X/SizeFactor;
            int iY = Start.Picture.Location.Y/SizeFactor;
            int size = Grasses.GetLength(0);
            Stack<Square> stack = new Stack<Square>();
            stack.Push(Start);
            Square Current = Start;
            while(stack.Count != 0)
            {
                Current = stack.Pop();
                HaveAlreadyVisited.Add(Current);
                iX = Current.Picture.Location.X/SizeFactor;
                iY = Current.Picture.Location.Y/ SizeFactor;
                if((iX + 1) < size)
                {
                    Checks(ref Grasses[iY, iX + 1], ref walls, ref stack, ref HaveAlreadyVisited);//right
                }
                if((iX - 1) >= 0)
                {
                    Checks(ref Grasses[iY, iX - 1], ref walls, ref stack, ref HaveAlreadyVisited);//left
                }
                if((iY + 1) < size)
                {
                    Checks(ref Grasses[iY + 1, iX], ref walls, ref stack, ref HaveAlreadyVisited);//bottom
                }
                if((iY - 1) >= 0)
                {
                    Checks(ref Grasses[iY - 1, iX], ref walls, ref stack, ref HaveAlreadyVisited);//top
                }
            }
            return walls;
        }
        private void StartSearch_Click(object sender, EventArgs e)
        {
            List<Square> walls = GetWalls();
            if (walls.Count == 0) return;

            // do the search
            // draw the results somehow
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HaveDrawnStart = false;
            HaveDrawnEnd = false;
            Start = null;
            End = null;
            int x = 0;
            int y = 0;
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    Grasses[i, z].Picture.Image = Resources.Grass;
                    Grasses[i, z].Picture.Size = Resources.Grass.Size;
                    Grasses[i, z].Type = Draw.Eraser;
                    x += SizeFactor;
                }
                y += SizeFactor;
                x = 0;
            }
            ImageToDraw = Resources.Grass;
            TypeOfOneToDraw = Draw.Eraser;

        }
    }
}