using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public class DataConfig
    {
        //
        // set the type of persistence
        //
        //public static DataType dataType = DataType.XML;
        public static DataType dataType = DataType.JSON;

        public static string DataPathJson => @"DataAccessLayer\DataJson\Widgets.json";
        public static string DataPathXml => @"DataAccessLayer\DataXml\Widgets.xml";
    }
}
