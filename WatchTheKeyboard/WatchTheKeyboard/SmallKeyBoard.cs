using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyBoardAssistant
{
   
    public partial class SmallKeyBoard : UserControl
    {
        Dictionary<string, Button> allButons;
      public SmallKeyBoard()
        {
            InitializeComponent();
          PlaceButtons();
        }

        private void PlaceButtons()
        {

             allButons = new Dictionary<string, Button>();

            var nums = new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "+", "|"};
               var qw = new[] {"Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "[", "]"};
                var asd = new[] { "A", "S", "D", "F", "G", "H", "J", "K", "L", ";", '"'.ToString() };
                  var zx = new[] { "Z", "X", "C", "V", "B", "N", "M", ",", ".", "?"};

            var buttonArrays = new List<string[]> {nums, qw, asd, zx};

            int topMargin = 10;
            int leftMargin = 5;
            const int middleSpan = 4;
            
            const int buttonHeight = 30;
            const int buttonWidht = 35;

            foreach (var buttonArray in buttonArrays)
            {
                
               
                int position = 0;
                int index = 0;
                foreach (var b in buttonArray)
                {
                    index++;
                    var btn = new Button();
                    btn.Text = b;
                    btn.Size = new Size(buttonWidht,buttonHeight);
                    btn.Location = new Point(leftMargin+index*(buttonWidht+middleSpan), topMargin);

                    allButons.Add(b,btn);
                    this.Controls.Add(btn);
                }

                leftMargin += buttonWidht/2;
                topMargin += buttonHeight+middleSpan*2;
            }

        }
      
        public void KeyDownM(string key)
        {
            if (allButons.ContainsKey(key))
            {
                allButons[key].BackColor = Color.Yellow;
            }
        }
        public void KeyUpM(string key)
        {
            if (allButons.ContainsKey(key))
            {
                allButons[key].BackColor = System.Drawing.SystemColors .Control;
                allButons[key].UseVisualStyleBackColor = false;
            }
        }

    }
}
