using Xunit;
using System.Text;

namespace tictactoe_csharp
{
    public class GameTest
    {
        [Fact]
        public void testOnlyAvailableMove()
        {
            var game = new Game("XOXOX-OXO");
            Assert.Equal(5, game.Move('X'));

            game = new Game("XOXOXOOX-");
            Assert.Equal(8, game.Move('O'));
        }

		[Fact]
        public void testStartingDefaultMove()
        {
            Game game = new Game("---------");
            Assert.Equal(0, game.Move('X'));
        }

		[Fact]
        public void testNoAvailableMove()
        {
            Game game = new Game("XXXXXXXXX");
            Assert.Equal(-1, game.Move('X'));
        }

        [Fact]
        public void testFindWinningRowMove()
        {
            Game game = new Game("OO-XX-OOX");
            Assert.Equal(5, game.Move('X'));
        }
		
		[Fact]
        public void testWinByRowConditions()
        {
            Game game = new Game("---XXX---");
            Assert.Equal('X', game.Winner());

            game = new Game("------OOO");
            Assert.Equal('O', game.Winner());

            game = new Game("YYY------");
            Assert.Equal('Y', game.Winner());
        }
    }

}
