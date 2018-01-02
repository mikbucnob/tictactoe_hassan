using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeHassan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeHassan.Tests
{
    [TestClass()]
    public class GameScreenTests
    {
        [TestMethod()]
        public void GameScreenTest()
        {
            GameScreen gs = new GameScreen();

            Assert.AreEqual(gs.Player_score, 0);
            Assert.AreEqual(gs.Computer_score, 0);
            Assert.AreEqual(gs.emptySpots, 9);
        }

        [TestMethod()]
        public void EmptySpotsTest()
        {
            GameScreen gs = new GameScreen();

            Assert.AreEqual(gs.emptySpots, 9);
        }

        [TestMethod()]
        public void FirstTurnPlayTest()
        {

            GameScreen gs = new GameScreen();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(gs);
            
        }

       
    }
}