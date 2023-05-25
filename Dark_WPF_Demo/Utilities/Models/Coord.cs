namespace AnhQuoc_OOP_C5_B2
{
    class Coord
    {
        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Constructors
        public Coord() { }
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
