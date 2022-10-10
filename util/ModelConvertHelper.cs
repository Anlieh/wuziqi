using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wuqizi
{
    class ModelConvertHelper<T> where T : new()
    {
        public static List<T> DataTable2List(DataTable dt)
        {
            // 定义集合    
            List<T> list = new List<T>();

            // 获得此模型的类型   
            Type type = typeof(T);
            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    // 检查DataTable是否包含此列 
                    tempName = pi.Name;     
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter      
                        if (!pi.CanWrite) { continue; }

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }


        public static Color ConvertColor(string color)
        {
            return color == "Black" ? Color.Black : Color.White;
        }

        public static string ConvertColor(Color color)
        {
            return color == Color.Black ? "Black" : "White";
        }

    }
}
