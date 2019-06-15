namespace BowlingKata
{
	public class Frame
	{
		private const int MaxPinsOfFrame = 10;
		private const int MaxRollsOfGame = 21;

		private readonly int[] _rolls = new int[MaxRollsOfGame];
		private int _throws;

		public int ScoreOfFrame(int theFrame)
		{
			_throws = 0;
			var score = 0;
			for (var current = 0; current < theFrame; current++)
			{
				if (IsStrike())
				{
					score += StrikeScore();
					_throws++;
				}
				else if (IsSpare())
				{
					score += SpareScore();
					_throws += 2;
				}
				else
				{
					score += NormalScore();
					_throws += 2;
				}
			}

			return score;
		}

		private bool IsSpare()
		{
			return _rolls[_throws] + _rolls[_throws + 1] == MaxPinsOfFrame;
		}

		private bool IsStrike()
		{
			return _rolls[_throws] == MaxPinsOfFrame;
		}

		private int NormalScore()
		{
			return _rolls[_throws] + _rolls[_throws + 1];
		}

		private int SpareScore()
		{
			return MaxPinsOfFrame + _rolls[_throws + 2];
		}

		private int StrikeScore()
		{
			return MaxPinsOfFrame + _rolls[_throws + 1] + _rolls[_throws + 2];
		}

		public void Roll(int currentRoll, int pins)
		{
			_rolls[currentRoll] = pins;
		}
	}
}