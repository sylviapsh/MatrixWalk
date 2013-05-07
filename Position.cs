namespace WalkInMatrix
{
    public class Position
    {       
        private int row;
        private int column;

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                this.column = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }
    }
}
