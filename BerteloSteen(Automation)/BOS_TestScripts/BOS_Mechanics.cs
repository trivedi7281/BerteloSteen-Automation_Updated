using BerteloSteen_Automation_.BOS_PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_TestScripts
{
    [TestFixture]
    class BOS_Mechanics : BaseClass
    {
        [Test]
        [Obsolete]
        public void MechanicsPage()
        {
            Mechanics mech = new Mechanics();
            mech.ClickonDARS();
            mech.GetPageTitle();
            //On Function it will click on the selected dealer and show the details.
            mech.SelectDealer("Bertel O. Steen Minde (015)");



        }
    }
}
