using System;

namespace Day_12
{
    class Ship
    {
        private int _x;
        private int _y;
        private Direction _dir;

        public Ship(Direction dir)
        {
            _dir = dir;
        }

        public void Move(int distance, bool forward)
        {
            if (!forward) distance = -distance;
            Move(distance, _dir);
        }

        public void Move(int count, (int, int) vector)
        {
            for (int i = 0; i < count; i++)
            {
                _x += vector.Item1;
                _y += vector.Item2;
            }
        }

        public void Move(int distance, Direction dir)
        {
            (int, int) vector = dir switch
            {
                Direction.N => (distance, 0),
                Direction.E => (0, distance),
                Direction.S => (-distance, 0),
                Direction.W => (0, -distance),
                _ => throw new Exception("Invalid Direction enum value"),
            };

            _x += vector.Item1;
            _y += vector.Item2;
        }

        public void Rotate(int degrees, bool right)
        {
            int rotations = degrees / 90;
            if (!right) rotations = 4 - rotations;
            int res = (DirToNum(_dir) + rotations) % 4;
            _dir = NumToDir(res);
        }

        public (int, int) Location => (_x, _y);

        private static int DirToNum(Direction dir) => dir switch
        {
            Direction.N => 0,
            Direction.E => 1,
            Direction.S => 2,
            Direction.W => 3,
            _ => throw new Exception("Invalid Direction enum value."),
        };

        private static Direction NumToDir(int num) => num switch
        {
            0 => Direction.N,
            1 => Direction.E,
            2 => Direction.S,
            3 => Direction.W,
            _ => throw new Exception("Number can't be converted to direction"),
        };
    }
}