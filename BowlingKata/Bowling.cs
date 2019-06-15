namespace BowlingKata
{
	public class Bowling
	{
		public int CurrentFrame
		{
			get => _currentFrame >= 10 ? 10 : _currentFrame;
			set => _currentFrame = value;
		}

		private int _rollIdx;
		private readonly int[] _rolls = new int[21];
		private bool _firstThrow = true;
		private int _currentFrame = 1;
		private int _throws = 0;

		public int Score()
		{
			return ScoreOfFrame(CurrentFrame);
		}

		public void Roll(int pins)
		{
			AdjustCurrentFrame(pins);
			_rolls[_rollIdx++] = pins;
		}

		private void AdjustCurrentFrame(int pins)
		{
			if (_firstThrow)
			{
				if (pins == 10)
				{
					_currentFrame++;
					return;
				}

				_firstThrow = false;
			}
			else
			{
				_firstThrow = true;
				_currentFrame++;
			}
		}

		public int ScoreOfFrame(int theFrame)
		{
			var score = 0;
			for (var current = 0; current < theFrame; current++)
			{
				if (IsStrike())
				{
					score += 10 + _rolls[_throws + 1] + _rolls[_throws + 2];
					_throws++;
				}
				else if (IsSpare())
				{
					score += 10 + SpareBonus();
					_throws += 2;
				}
				else
				{
					score += _rolls[_throws] + _rolls[_throws + 1];
					_throws += 2;
				}
			}

			return score;
		}

		private int SpareBonus()
		{
			return _rolls[_throws + 2];
		}

		private bool IsSpare()
		{
			return _rolls[_throws] + _rolls[_throws + 1] == 10;
		}

		private bool IsStrike()
		{
			return _rolls[_throws] == 10;
		}

		private int SpareBonus(int ball)
		{
			return _rolls[ball + 2];
		}
	}
}