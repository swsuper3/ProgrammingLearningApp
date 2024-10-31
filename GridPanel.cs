using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class GridPanel : Panel
    {
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            //this.Invalidate();
        }
    }
}
