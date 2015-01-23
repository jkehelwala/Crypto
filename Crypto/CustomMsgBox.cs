using System.Windows.Forms;

namespace Crypto
{
    enum Msg { Success, Exception, Information, Error };
    class CustomMsgBox
    {                
        public static void Show(string caption, string msg, Msg picture)
        {
            Form MsgBox = new Form();
            MsgBox.Width = 300;
            MsgBox.Height = 150;
            MsgBox.Text = caption;
            MsgBox.StartPosition = FormStartPosition.CenterScreen;
            MsgBox.BackColor = System.Drawing.Color.White;
            MsgBox.TopMost = true;
            MsgBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MsgBox.MaximizeBox = false;
            MsgBox.MinimizeBox = false;
            MsgBox.ShowInTaskbar = false;
            MsgBox.ShowIcon = false;
            PictureBox pbxMsgPic = new PictureBox() { Left = 0, Top = 0, SizeMode = PictureBoxSizeMode.StretchImage, Height = 70, Width = 70, Image = getImage(picture)};
            Label lblMessage = new Label() { Left = 75, Top = 0, Width = 185, Height = 65, Text = msg, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            Panel panelMsg = new Panel() { Width = 275, Height = 70, Left = 15, Top = 10 }; 
            Button btnConfirm = new Button() { Text = "OK", Left = 120, Top = 80, Height = 30, Width = 70, FlatStyle = FlatStyle.System};
            btnConfirm.Click += (sender, e) => { MsgBox.Dispose(); };
            panelMsg.Controls.Add(pbxMsgPic);
            panelMsg.Controls.Add(lblMessage);
            MsgBox.Controls.Add(panelMsg);
            MsgBox.Controls.Add(btnConfirm);
            MsgBox.AcceptButton = btnConfirm;
            MsgBox.ShowDialog();
        }

        public static void Show(string msg, Msg picture)
        {
            Show(picture.ToString(), msg, picture);
        }

        private static System.Drawing.Bitmap getImage(Msg img)
        {
            switch (img)
            {
                case Msg.Success:
                    return Crypto.Properties.Resources.msgdone;
                case Msg.Exception:
                    return Crypto.Properties.Resources.msgcross;
                case Msg.Error:
                    return Crypto.Properties.Resources.msgcross;
                case Msg.Information:
                    return Crypto.Properties.Resources.msginfo;
                default:
                    return Crypto.Properties.Resources.msginfo;
            }
        }



    }

}
