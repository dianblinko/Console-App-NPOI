using System;
using System.Collections.Generic;
using System.IO;
using NPOI.XWPF.UserModel;

namespace BashNIPI2
{
    internal class Program
    {
        static List<Simple> _listObjects;
        static int _countObjects;
        static int _countSimpleObjects;
        static int _countCollectionObjects;

        static void Main(string[] args)
        {
            _listObjects = new List<Simple>();
            Console.WriteLine("Введите количество объектов");
            _countObjects = Convert.ToInt32(Console.ReadLine());
            GenerateObjectsList();
            GenerateReport();
        }

        static void GenerateObjectsList()
        {
            Random rand = new Random();
            _countSimpleObjects = rand.Next(1, _countObjects);
            _countCollectionObjects = _countObjects - _countSimpleObjects;

            for (int i = 0; i < _countSimpleObjects; i++)
            {
                _listObjects.Add(new Simple(i, rand));
            }

            for (int i = 0; i < _countCollectionObjects; i++)
            {
                _listObjects.Add(new Collection(i, rand));
            }
        }
        
        static void GenerateReport()
        {
            Console.WriteLine("Запуск формирования отчета");
            XWPFDocument doc = new XWPFDocument();
            doc.CreateTOC();
            
            Console.WriteLine("Формирование перечня всех объектов");
            XWPFParagraph p1AllObjects = doc.CreateParagraph();
            p1AllObjects.IsPageBreak = true;
            p1AllObjects.Style = "Heading1";
            XWPFRun r1 = p1AllObjects.CreateRun();
            r1.FontSize = 16;
            r1.FontFamily = "Times New Roman";
            r1.SetText("Перечень всех объектов");
            
            XWPFTable tableAllObjects = doc.CreateTable(_countObjects+1, 3);
            tableAllObjects.GetRow(0).GetCell(0).SetText("Номер");
            tableAllObjects.GetRow(0).GetCell(1).SetText("Название объекта");
            tableAllObjects.GetRow(0).GetCell(2).SetText("Тип объекта");

            for (int i = 0; i < _countObjects; i++)
            {
                tableAllObjects.GetRow(i+1).GetCell(0).SetText((i+1).ToString());
                tableAllObjects.GetRow(i+1).GetCell(1).SetText(_listObjects[i].Name);
                tableAllObjects.GetRow(i+1).GetCell(2).SetText(_listObjects[i].GetType().ToString().Split(".")[1]);
            }
            
            Console.WriteLine("Формирование описания объектов Simple");
            XWPFParagraph p2SimpleObjects = doc.CreateParagraph();
            p2SimpleObjects.IsPageBreak = true;
            p2SimpleObjects.Style = "Heading1";
            XWPFRun r2 = p2SimpleObjects.CreateRun();
            r2.FontSize = 16;
            r2.FontFamily = "Times New Roman";
            r2.SetText("Описание объектов типа Simple");
            for (int i = 0; i < _countSimpleObjects; i++)
            {
                doc.CreateParagraph();
                XWPFTable tableSimple = doc.CreateTable(typeof(Simple).GetProperties().Length + 1, 2);
                tableSimple.GetRow(0).GetCell(0).SetText("Свойство");
                tableSimple.GetRow(0).GetCell(1).SetText("Значение");
                
                var cellCount = 1;
                foreach (var prop in typeof(Simple).GetProperties())
                {
                    tableSimple.GetRow(cellCount).GetCell(0).SetText(Simple.GetPropertyDisplayName(prop.Name));
                    var val = prop.GetValue(_listObjects[i]);
                    tableSimple.GetRow(cellCount).GetCell(1).SetText(val?.ToString());
                    cellCount++;
                }
            }
            
            Console.WriteLine("Формирование описания объектов Collection");
            XWPFParagraph p3CollectionObjects = doc.CreateParagraph();
            p3CollectionObjects.IsPageBreak = true;
            p3CollectionObjects.Style = "Heading1";
            XWPFRun r3 = p3CollectionObjects.CreateRun();
            r3.FontSize = 16;
            r3.FontFamily = "Times New Roman";
            r3.SetText("Описание объектов типа Collection");
            for (int i = _countSimpleObjects; i < _countObjects; i++)
            {
                doc.CreateParagraph();
                XWPFTable tableCollection = doc.CreateTable(typeof(Collection).GetProperties().Length + 1, 2);
                tableCollection.GetRow(0).GetCell(0).SetText("Свойство");
                tableCollection.GetRow(0).GetCell(1).SetText("Значение");
                
                var cellCount = 1;
                foreach (var prop in typeof(Collection).GetProperties())
                {
                    tableCollection.GetRow(cellCount).GetCell(0).SetText(Simple.GetPropertyDisplayName(prop.Name));
                    var val = prop.GetValue(_listObjects[i]);
                    tableCollection.GetRow(cellCount).GetCell(1).SetText(val?.ToString());
                    cellCount++;
                }
                
                // Подтаблица Pipe
                // Collection collection = _listObjects[i] as Collection;
                // XWPFTable tablePipe = doc.CreateTable(2, collection.Pipe.Count + 1);
                //
                // tablePipe.GetRow(0).GetCell(0).SetText(collection.Pipe[0].Pressure.ToString());
                // tablePipe.GetRow(1).GetCell(0).SetText(collection.Pipe[1].Pressure.ToString());
                // int index = 1;
                // foreach (var pipe in collection.Pipe)
                // {
                //     tablePipe.GetRow(0).GetCell(index).SetText(pipe.LengthFromBeginningPipe.ToString());
                //     tablePipe.GetRow(1).GetCell(index).SetText(pipe.Pressure.ToString());
                //     index++;
                // }
            }
            
            FileStream out1 = new FileStream("Report.docx", FileMode.Create);
            doc.Write(out1);
            out1.Close();
        }
        
    }
}

/*
11)	Раздел «Описание объектов типа Collection» должен содержать набор таблиц для каждого объекта из списка с типом Simple. 
    Количество колонок соответствует количеству свойств объекта. После каждой таблицы необходимо поместить график, 
    построенный на основе свойства Pipe, т.е. зависимость давления от глубины.
*/