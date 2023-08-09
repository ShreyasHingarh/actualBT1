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
        public int SizeFactor = 30;
        public int ScreenSize = 810;
        bool HaveDrawnStart;
        bool HaveDrawnEnd;


        Draw TypeOfOneToDraw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            ImageToDraw = Resources.Grass;
            TypeOfOneToDraw = Draw.Eraser;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            ImageValues = JsonConvert.DeserializeObject<List<byte>>(File.ReadAllText(@"C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\MapEditor\MapEditor\TextFile1.txt"));
            int index = 0;
            foreach(var item in Grasses)
            {
                switch (ImageValues[index])
                {
                    case 0:
                        item.Picture.Image = Resources.Grass;
                        break;
                    case 1:
                        item.Picture.Image = Resources.Startx;
                        break;
                    case 2:
                        item.Picture.Image = Resources.Endx;
                        break;
                    case 3:
                        item.Picture.Image = Resources.Path;
                        break;
                }
                index++;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            List<byte> temp = ImageValues;
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
            File.WriteAllText(@"C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\MapEditor\MapEditor\TextFile1.txt", x);
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
                            HaveDrawnStart = false;
                        }
                        if (Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.End)
                        {
                            HaveDrawnEnd = false;
                        }
                        break;
                    case Draw.Start:
                        if (HaveDrawnStart) return;
                        if (!HaveDrawnStart)
                        {
                            HaveDrawnStart = true;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Image = ImageToDraw;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Size = ImageToDraw.Size;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type = Draw.Start;
                            return;
                        }
                        break;
                    case Draw.End:
                        if (HaveDrawnEnd) return;
                        if (!HaveDrawnEnd)
                        {
                            HaveDrawnEnd = true;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Image = ImageToDraw;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Size = ImageToDraw.Size;
                            Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type = Draw.End;
                            return;
                        }
                        break;
                }
                if ((Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.End || Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type == Draw.Start) && TypeOfOneToDraw == Draw.Path) return;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Image = ImageToDraw;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Picture.Size = ImageToDraw.Size;
                Grasses[temp.Y / SizeFactor, temp.X / SizeFactor].Type = TypeOfOneToDraw;
            }
        }

        private void StartSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HaveDrawnStart = false;
            HaveDrawnEnd = false;
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