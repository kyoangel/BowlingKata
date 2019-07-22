namespace BowlingKata
{
	public class Bowling
	{
		private bool _firstThrow = true;
		private int _throwCounts;
		private readonly int[] _pinsOfRolls = new int[21];
		private int _frame = 1;

		public int Frame
		{
			get => _frame > 10 ? 10 : _frame;
			set => _frame = value;
		}

		public int Score()
		{
			return ScoreOfFrame(Frame);
		}

		public void Roll(int pins)
		{
			if (_firstThrow)
			{
				if (pins == 10)
				{
					Frame++;
				}
				else
				{
					_firstThrow = false;
				}
			}
			else
			{
				_firstThrow = true;
				Frame++;
			}

			_pinsOfRolls[_throwCounts++] = pins;
		}

		public int ScoreOfFrame(int theFrame)
		{
			var score = 0;
			var rollIndex = 0;
			for (var i = 0; i < theFrame; i++)
			{
				if (_pinsOfRolls[rollIndex] == 10)
				{
					score += 10 + _pinsOfRolls[rollIndex + 1] + _pinsOfRolls[rollIndex + 2];
					rollIndex += 1;
				}
				else if (_pinsOfRolls[rollIndex] + _pinsOfRolls[rollIndex + 1] == 10)
				{
					score += 10 + _pinsOfRolls[rollIndex + 2];
					rollIndex += 2;
				}
				else
				{
					score += _pinsOfRolls[rollIndex] + _pinsOfRolls[rollIndex + 1];
					rollIndex += 2;
				}
			}
			return score;
		}
	}
}