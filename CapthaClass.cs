using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo
{
    public class CapthaClass
    {
        /// <summary>
        /// Значение капчи
        /// </summary>
        public string Captha { get; set; }

        /// <summary>
        /// Генерация новой капчи
        /// </summary>
        public void Generate()
        {
            var r = new Random(); 
            Captha = "";
            for (int i = 0; i < 4; i++) // добавляем 4 случайных символа
            {
                Captha += (char)r.Next(65, 123); // 65 симвл в таблице ascii - A, 123 - z
            }
        }
    }
}
