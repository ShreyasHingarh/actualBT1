using MapEditor.Properties;

using Microsoft.VisualBasic.Devices;

using System.Numerics;
using System.Security.Policy;

namespace MapEditor
{
    
    public partial class Form1 : Form
    {
        public Square[,] Grasses;
        public Image ImageToDraw;

        bool HaveDrawnStart;
        bool HaveDrawnEnd;

        
        Draw TypeOfOneToDraw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HaveDrawnStart = false;
            HaveDrawnEnd = false;
            int x = 30;
            int y = 30;
            Grasses = new Square[(600 / x),(600 / y)];
            x = 0;
            y = 0;
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    Grasses[i, z] = new Square();
                    ; 
                    Grasses[i,z].Picture.Image = Resources.Grass;
                    Grasses[i,z].Picture.Location = new Point(x, y);
                    Grasses[i,z].Picture.Size = new Size(Resources.Grass.Width, Resources.Grass.Height);
                    Grasses[i,z].Picture.Visible = true;
                    x += 30;
                    Controls.Add(Grasses[i,z].Picture);
                }
                y += 30;
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

        }

        private void Save_Click(object sender, EventArgs e)
        {

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
            while(x < 600)
            {
                if(Location.X >= x && Location.X < x + 30)
                {
                    point.X = x;
                    break;
                }
                x += 30;
            }
            int y = 0;
            while (y < 600)
            {
                if (Location.Y >= y && Location.Y < y + 30)
                {
                    point.Y = y;
                    break;
                }
                y += 30;
            }
            return point;
        }
        
        private void Update_Tick(object sender, EventArgs e)
        {
            Rectangle mouse = new Rectangle(PointToClient(Cursor.Position), new Size(0, 0));
            Rectangle BoundryForScreen = new Rectangle(TheScreen.Location,TheScreen.Size);
            if (BoundryForScreen.Contains(mouse) && MouseButtons == MouseButtons.Left)
            {
                Point temp = GetNearestLocation(mouse.Location);
                switch (TypeOfOneToDraw)
                {
                    case Draw.Eraser:
                        if (Grasses[temp.Y / 30, temp.X / 30].Type == Draw.Start)
                        {
                            HaveDrawnStart = false;
                        }
                        if (Grasses[temp.Y / 30, temp.X / 30].Type == Draw.End)
                        {
                            HaveDrawnEnd = false;
                        }
                        break;
                    case Draw.Start:
                        if (HaveDrawnStart) return;
                        if (!HaveDrawnStart)
                        {
                            HaveDrawnStart = true;
                            Grasses[temp.Y / 30, temp.X / 30].Picture.Image = ImageToDraw;
                            Grasses[temp.Y / 30, temp.X / 30].Picture.Size = ImageToDraw.Size;
                            return;
                        }
                        break;
                    case Draw.End:
                        if (HaveDrawnEnd) return;
                        if (!HaveDrawnEnd)
                        {
                            HaveDrawnEnd = true;
                            Grasses[temp.Y / 30, temp.X / 30].Picture.Image = ImageToDraw;
                            Grasses[temp.Y / 30, temp.X / 30].Picture.Size = ImageToDraw.Size;
                            return;
                        }
                        break;
                }  
                Grasses[temp.Y / 30, temp.X / 30].Picture.Image = ImageToDraw;
                Grasses[temp.Y / 30, temp.X / 30].Picture.Size = ImageToDraw.Size;
                Grasses[temp.Y / 30, temp.X / 30].Type = TypeOfOneToDraw;
            }
        }

        private void StartSearch_Click(object sender, EventArgs e)
        {

        }
    }
}