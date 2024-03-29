namespace BCTest.DB
{
    public static  class DBList
    {
        public static List<int> examineeList;
        public static List<int> orderExamineeList;
        static DBList()
        {
            examineeList = new List<int>();
            orderExamineeList = new List<int>();
        }
    }
}
