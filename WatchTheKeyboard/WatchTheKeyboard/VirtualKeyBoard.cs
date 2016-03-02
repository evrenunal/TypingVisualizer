using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace WatchTheKeyboard
{
    public partial class VirtualKeyBoard : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;


        public VirtualKeyBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Subscribe();
        }

        public void Subscribe()
        {
            
            m_GlobalHook = Hook.GlobalEvents();
           
            m_GlobalHook.KeyDown += m_GlobalHook_KeyDown;
            m_GlobalHook.KeyUp += m_GlobalHook_KeyUp;
        }

        public void Unsubscribe()
        {

            m_GlobalHook.KeyDown -= m_GlobalHook_KeyDown;
            m_GlobalHook.KeyUp -= m_GlobalHook_KeyUp;

            m_GlobalHook.Dispose();
        }

        private void m_GlobalHook_KeyUp(object sender, KeyEventArgs e)
        {
            var k = KeycodeToChar(e.KeyValue);

            if (!string.IsNullOrEmpty(k))
                smallKeyBoard1.KeyUpM(k);

            var kc = new KeysConverter();

            this.smallKeyBoard1.KeyUpM(kc.ConvertToString(e.KeyData));
        }

        private void m_GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            var k = KeycodeToChar(e.KeyValue);

            if (!string.IsNullOrEmpty(k))
                smallKeyBoard1.KeyDownM(k);
           
            var kc = new KeysConverter();

            this.smallKeyBoard1.KeyDownM(kc.ConvertToString(e.KeyValue));
        }

        public String KeycodeToChar(int keyCode)
        {
            Keys key = (Keys)keyCode;

            switch (key)
            {
                case Keys.Add:
                    return "+";
                case Keys.Decimal:
                    return ".";
                case Keys.Divide:
                    return "/";
                case Keys.Multiply:
                    return "*";
                case Keys.OemBackslash:
                    return "\\";
                case Keys.OemCloseBrackets:
                    return "]";
                case Keys.OemMinus:
                    return "-";
                case Keys.OemOpenBrackets:
                    return "[";
                case Keys.OemPeriod:
                    return ".";
                case Keys.OemPipe:
                    return "|";
                case Keys.OemQuestion:
                    return "?";
                case Keys.OemQuotes:
                    return "\"";
                case Keys.OemSemicolon:
                    return ";";
                case Keys.Oemcomma:
                    return ",";
                case Keys.Oemplus:
                    return "+";
                case Keys.Oemtilde:
                    return "`";
                case Keys.Separator:
                    return "-";
                case Keys.Subtract:
                    return "-";
                case Keys.D0:
                    return "0";
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.Space:
                    return " ";

                default:
                    return String.Empty;
            }
        }
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Unsubscribe();
        }
        
    }
}
