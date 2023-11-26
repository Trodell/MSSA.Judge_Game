using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JudgeGameV2
{
    internal class Prisoner
    {
        public string Crime { get; set; }
        public int RecommitStart {  get; set; }
        public int RecommitEnd { get; set; }
        public string soundPlayer { get; set; }
        public PictureBox PictureBox { get; set; }
    }
}
