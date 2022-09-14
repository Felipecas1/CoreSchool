using CoreSchoolProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.App
{
    public class Reporter
    {
        Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> _dictionary;
        public Reporter(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dicObjSch)
        {
            if (dicObjSch == null)
            {
                throw new ArgumentNullException(nameof(dicObjSch));
            }
            _dictionary = dicObjSch;
        }

        public IEnumerable<Test> GetListTests()
        {
            if (_dictionary.TryGetValue(KeyDictionary.Test, out IEnumerable<BaseSchoolObject> lista))
            {
                return lista.Cast<Test>();
            }
            {
                return new List<Test>();
            }
        }
        public IEnumerable<string> GetListSubjecst()
        {
            return GetListSubjecst(out var dummy);
        }
        public IEnumerable<string> GetListSubjecst(out IEnumerable<Test> listTest)
        {
            listTest = GetListTests();

            return (from te in listTest
                    select te.Subject.Name).Distinct();
        }
        public Dictionary<string, IEnumerable<Test>> GetDicTestXSubject()
        {
            var testDic = new Dictionary<string, IEnumerable<Test>>();
            var listSubje = GetListSubjecst(out var listTest);

            foreach (var sub in listSubje)
            {
                var testSubje = from te in listTest
                                where te.Subject.Name == sub
                                select te;

                testDic.Add(sub, testSubje);
            }
            return testDic;
        }
        public Dictionary<string, IEnumerable<object>> GetPromStuXSub()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicTestXSubj = GetDicTestXSubject();

            foreach (var subWithSub in dicTestXSubj)
            {
                var dummy = from te in subWithSub.Value
                            select new
                            {
                                te.Student.UniqueId,
                                studentName = te.Student.Name,
                                subjectName = te.Name,
                                te.Calification
                            };
            }
            return rta;
        }
    }
}