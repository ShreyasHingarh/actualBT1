using MapEditor.Properties;

using Microsoft.VisualBasic.Devices;

using System.Numerics;
using System.Security.Policy;
using Newtonsoft.Json;

namespace MapEditor
{

    public partial class Form1 : Form
    {
        public Vertex[,] Grasses;
        public Image ImageToDraw;
        public List<byte> ImageValues;
        public Vertex Start;
        public Vertex End;
        public int SizeFactor = 30;
        public int ScreenSize = 810;
        public BuildGraph buildGraph;
        bool HaveDrawnStart;
        bool HaveDrawnEnd;
        Draw TypeOfOneToDraw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buildGraph = new BuildGraph();
            ImageValues = new List<byte>();
            HaveDrawnStart = false;
            HaveDrawnEnd = false;
            int x = SizeFactor;
            int y = SizeFactor;
            Grasses = new Vertex[(ScreenSize / x), (ScreenSize / y)];
            x = 0;
            y = 0;
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    Grasses[i, z] = new Vertex(new Square(z, i));
                    Grasses[i, z].Value.Picture.Image = Resources.Grass;
                    Grasses[i, z].Value.Picture.Location = new Point(x, y);
                    Grasses[i, z].Value.Picture.Size = new Size(Resources.Grass.Width, Resources.Grass.Height);
                    Grasses[i, z].Value.Picture.Visible = true;
                    Grasses[i, z].Value.Type = Draw.Eraser;
                    x += SizeFactor;
                    Controls.Add(Grasses[i, z].Value.Picture);
                }
                y += SizeFactor;
                x = 0;
            }
            ImageToDraw = Resources.Grass;
            TypeOfOneToDraw = Draw.Eraser;
            buildGraph.InitializeVerticies(Grasses);
            buildGraph.InitializeEdges(Grasses);
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
            ImageValues = JsonConvert.DeserializeObject<List<byte>>(File.ReadAllText(@"..\..\..\..\MapEditor\Background.txt"));
            int index = 0;
            foreach (var item in Grasses)
            {
                switch (ImageValues[index])
                {
                    case 0:
                        item.Value.Picture.Image = Resources.Grass;
                        item.Value.Type = Draw.Eraser;
                        break;
                    case 1:
                        item.Value.Picture.Image = Resources.Startx;
                        item.Value.Type = Draw.Start;
                        HaveDrawnStart = true;
                        Start = item;
                        break;
                    case 2:
                        item.Value.Picture.Image = Resources.Endx;
                        item.Value.Type = Draw.End;
                        HaveDrawnEnd = true;
                        End = item;
                        break;
                    case 3:
                        item.Value.Picture.Image = Resources.Path;
                        item.Value.Type = Draw.Path;
                        break;
                }
                index++;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ImageValues.Clear();
            foreach (var item in Grasses)
            {
                switch (item.Value.Type)
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
            File.WriteAllText(@"..\..\..\..\MapEditor\Background.txt", x);
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
                        if (Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type == Draw.Start)
                        {
                            Start = null;
                            HaveDrawnStart = false;
                        }
                        if (Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type == Draw.End)
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
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Picture.Image = ImageToDraw;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type = Draw.Start;
                            return;
                        }
                        break;
                    case Draw.End:
                        if (HaveDrawnEnd) return;
                        if (!HaveDrawnEnd)
                        {
                            End = Grasses[temp.Y / SizeFactor, temp.X / SizeFactor];
                            HaveDrawnEnd = true;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Picture.Image = ImageToDraw;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type = Draw.End;
                            return;
                        }
                        break;
                }
                if ((Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type == Draw.End || Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type == Draw.Start) && TypeOfOneToDraw == Draw.Path) return;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Picture.Image = ImageToDraw;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Value.Type = TypeOfOneToDraw;
            }
        }
        public void Checks(ref Vertex curNeighbor, ref List<Vertex> walls, ref Stack<Vertex> stack, ref List<Vertex> HaveAlreadyVisited)
        {
            if (!HaveAlreadyVisited.Contains(curNeighbor))
            {
                if (curNeighbor.Value.Type == Draw.Eraser && !walls.Contains(curNeighbor))
                {
                    curNeighbor.IsWall = true;
                    walls.Add(curNeighbor);
                }
                else if (curNeighbor.Value.Type != Draw.Eraser)
                {
                    stack.Push(curNeighbor);
                }
            }
        }
        public void SetWalls()
        {
            List<Vertex> HaveAlreadyVisited = new List<Vertex>();
            List<Vertex> walls = new List<Vertex>();
            if (Start == null || End == null) return;
            int iX = Start.Value.Picture.Location.X / SizeFactor;
            int iY = Start.Value.Picture.Location.Y / SizeFactor;
            int size = Grasses.GetLength(0);
            Stack<Vertex> stack = new Stack<Vertex>();
            stack.Push(Start);
            Vertex Current = Start;
            while (stack.Count != 0)
            {
                Current = stack.Pop();
                HaveAlreadyVisited.Add(Current);
                iX = Current.Value.Picture.Location.X / SizeFactor;
                iY = Current.Value.Picture.Location.Y / SizeFactor;
                if ((iX + 1) < size)
                {
                    Checks(ref Grasses[iY, iX + 1], ref walls, ref stack, ref HaveAlreadyVisited);//right
                }
                if ((iX - 1) >= 0)
                {
                    Checks(ref Grasses[iY, iX - 1], ref walls, ref stack, ref HaveAlreadyVisited);//left
                }
                if ((iY + 1) < size)
                {
                    Checks(ref Grasses[iY + 1, iX], ref walls, ref stack, ref HaveAlreadyVisited);//bottom
                }
                if ((iY - 1) >= 0)
                {
                    Checks(ref Grasses[iY - 1, iX], ref walls, ref stack, ref HaveAlreadyVisited);//top
                }
            }
            return;
        }
        private void StartSearch_Click(object sender, EventArgs e)
        {
            SetWalls();
            List<Vertex> Path = buildGraph.Graph.AStarThing(Start, End);
            List<Position> positionsOfPath = new List<Position>();
            foreach (var item in Path)
            {
                positionsOfPath.Add(item.Value.location);
            }
            string x = JsonConvert.SerializeObject(positionsOfPath);
            File.WriteAllText(@"..\..\..\..\MapEditor\Path.txt", string.Empty);
            File.WriteAllText(@"..\..\..\..\MapEditor\Path.txt", x);
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
                    Grasses[i, z].Value.Picture.Image = Resources.Grass;
                    Grasses[i, z].Value.Picture.Size = Resources.Grass.Size;
                    Grasses[i, z].Value.Type = Draw.Eraser;
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