using System.Drawing;
using System.Windows.Forms;

namespace Overlay_PictureBox_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //重ねて表示するために両方の位置を(0,0)に設定
            pictureBox1.Location = new Point(0, 0);
            pictureBox2.Location = new Point(0, 0);

            //大きさを(500,500)に設定
            pictureBox1.ClientSize = new Size(500, 500);
            pictureBox2.ClientSize = new Size(500, 500);

            //pictureBox2の親要素をpictureBox1に設定する
            pictureBox2.Parent = pictureBox1;

            //pictureBox1に色を塗る(わかりやすくするため)
            pictureBox1.BackColor = Color.DeepSkyBlue;

            //pictureBox2を透過させる
            pictureBox2.BackColor = Color.Transparent;
        }
        Bitmap overlay = new Bitmap(500, 500);
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(overlay);

            //透明色で塗りつぶす
            graphics.Clear(Color.Transparent);

            //四角形の描写
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            graphics.FillRectangle(blueBrush, e.X, e.Y, 70, 70);

            //graphicsの開放
            graphics.Dispose();

            pictureBox2.Image = overlay;
        }
    }
}
