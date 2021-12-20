using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Avansight.Service
{
    public class HelperService
    {
        public static DataSet ReadExcelToDataSet(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var reader = ExcelReaderFactory.CreateReader(stream);
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = false,
                        ReadHeaderRow = (rowReader) => {
                            rowReader.Read();
                        },
                    }
                };
                return reader.AsDataSet(conf);
            }


        }
    }
}

