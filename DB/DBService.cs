using BCTest.Controllers;
using System.Data;

namespace BCTest.DB

{
    public class DBService : IBDService
    {
        private readonly ILogger<TestController> _logger;
        public DBService(ILogger<TestController> logger) 
        {
            _logger = logger;
        }

        //public List<int> examinee = new List<int>();
        //public List<int> orderExaminee = new List<int>();


        public List<int> GetExaminee(int n)
        {
            if (n <= 20)
            {
                _logger.LogWarning("考生数量必须大于20，低于20无法创建考生列表！");
                return new List<int>();
            }

            Random rnd = new Random();
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                do
                {
                    num = rnd.Next(0, n + 1);
                } while (DBList.examineeList.Contains(num));
                DBList.examineeList.Add(num);
            }
            _logger.LogInformation("包含{n}个考生的列表创建成功！", n);
            return DBList.examineeList;
        }

        public List<int> GetOrderExaminee()
        {
            if (!DBList.examineeList.Any())
            {
                _logger.LogWarning("考生列表不存在，无法重排考生列表");
                return new List<int>();
            }

            int firstExamine = DBList.examineeList.FirstOrDefault();
            int insertExaminee = DBList.examineeList.LastOrDefault();
            DBList.examineeList.Remove(insertExaminee);
            foreach (var item in  DBList.examineeList)
            {
                if (item == firstExamine)
                {
                    DBList.orderExamineeList.Add(item);
                    DBList.orderExamineeList.Add(insertExaminee);
                }
                else
                {
                    DBList.orderExamineeList.Add(item);
                }
               
            }
            _logger.LogInformation("考生列表重排成功！");
            return DBList.orderExamineeList;
        }
    }

      
    
}
