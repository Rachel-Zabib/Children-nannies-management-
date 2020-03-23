using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    class Dal_XML_imp : Idal
    {
        XElement childRoot;
        string pathChild = "..//..//..//xmlFiles//xmlChild.xml";

        string pathNanny = "..//..//..//xmlFiles//xmlNanny.xml";
        string pathMother = "..//..//..//xmlFiles//xmlMother.xml";
        string pathContract = "..//..//..//xmlFiles//xmlContract.xml";

        public Dal_XML_imp()
        {
            XElement help = XElement.Load("..//..//..//xmlFiles//config.xml");
            Contract.counter = int.Parse(help.Element("counter").Value);


            if(!File.Exists(pathContract))
            {
                List<Contract> conList = new List<Contract>();//empty list for start
                SaveToXML<List<Contract>>(conList, pathContract);
            }

            if (!File.Exists(pathMother))
            {
                List<Mother> momList = new List<Mother>();//empty list for start
                SaveToXML<List<Mother>>(momList, pathMother);
            }

            if (!File.Exists(pathNanny))
            {
                List<Nanny> nanList = new List<Nanny>();//empty list for start
                SaveToXML<List<Nanny>>(nanList, pathNanny);
            }

            if (!File.Exists(pathChild))//we have to add new file
                CreateFileChild();
            else//ensure all data is according to current information
                LoadDataChild();
        }

        private void LoadDataChild()//load from file to program
        {
            try
            {
                childRoot = XElement.Load(pathChild);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        private void CreateFileChild()//for new file
        {
            childRoot = new XElement("children");
            childRoot.Save(pathChild);//add new main element
        }

        public static void SaveToXML<T>(T source, string path)//save objects like elements from program to  file
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }

        public static T LoadFromXML<T>(string path)//save elements like objects from file to program 
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }


        #region child
        public void Add_Child(Child child1)
        {

            LoadDataChild();

            Child ch = Get_Child(child1.Id);//check if this id already exits
            if (ch != null)//it means there is already such a child
                throw new Exception("there is already a child with the same id");

            XElement id = new XElement("id", child1.Id);
            XElement momId = new XElement("momId", child1.Mother_Id);
            XElement firstName = new XElement("firstName", child1.First_Name);
            XElement birthDate = new XElement("birthDate", child1.Birth_Date);
            XElement isSpecialNeeds = new XElement("isSpecialNeeds", child1.Is_Special_Needs);
            XElement specialNeeds = new XElement("specialNeeds", child1.Special_Needs);
            XElement isAllergy = new XElement("isAllergy", child1.Is_Allergy);
            XElement allergy = new XElement("allergy", child1.Allergy);
            XElement diapers = new XElement("diapers", child1.Without_Diapers);

            XElement complete = new XElement("child", id, momId, firstName, birthDate, isSpecialNeeds, specialNeeds, isAllergy, allergy, diapers);

            childRoot.Add(complete);//add new child to all children in file

            childRoot.Save(pathChild);

        }


        public Child Get_Child(int id)
        {
            LoadDataChild();
            Child returnCh;
            returnCh = (from chElement in childRoot.Elements()
                        where int.Parse(chElement.Element("id").Value) == id
                        select new Child()//convert from element in file to object of child
                        {

                            Id = int.Parse(chElement.Element("id").Value),
                            Mother_Id = int.Parse(chElement.Element("momId").Value),
                            First_Name = chElement.Element("firstName").Value,
                            Birth_Date = DateTime.Parse(chElement.Element("birthDate").Value),
                            Is_Special_Needs = bool.Parse(chElement.Element("isSpecialNeeds").Value),
                            Special_Needs = chElement.Element("specialNeeds").Value,
                            Is_Allergy = bool.Parse(chElement.Element("isAllergy").Value),
                            Allergy = chElement.Element("allergy").Value,
                            Without_Diapers = bool.Parse(chElement.Element("diapers").Value)
                        }).FirstOrDefault();

            return returnCh;
        }

        public IEnumerable<Child> Get_All_Children(Func<Child, bool> predicate = null)
        {
            LoadDataChild();
            //collect elments of children to ienumerable
            IEnumerable<Child> allChild = from chElement in childRoot.Elements()
                                          select new Child()//convert from element in file to object of child
                                          {
                                              Id = int.Parse(chElement.Element("id").Value),
                                              Mother_Id = int.Parse(chElement.Element("momId").Value),
                                              First_Name = chElement.Element("firstName").Value,
                                              Birth_Date = DateTime.Parse(chElement.Element("birthDate").Value),
                                              Is_Special_Needs = bool.Parse(chElement.Element("isSpecialNeeds").Value),
                                              Special_Needs = chElement.Element("specialNeeds").Value,
                                              Is_Allergy = bool.Parse(chElement.Element("isAllergy").Value),
                                              Allergy = chElement.Element("allergy").Value,
                                              Without_Diapers = bool.Parse(chElement.Element("diapers").Value)
                                          };

            if (predicate == null)//no condition
                return allChild;
            else
                return allChild.Where(predicate);
        }

        public bool Remove_Child(int id)
        {
            LoadDataChild();
            XElement removeChildElement;
            //find wanted to be deleted
            removeChildElement = (from chElement in childRoot.Elements()
                                  where int.Parse(chElement.Element("id").Value) == id
                                  select chElement).FirstOrDefault();
            if (removeChildElement == null)//cant remove cause didnt find
                throw new Exception("no such child");

            //delete contracts of child:
            List<Contract> conList = GetAll_Contract().ToList();
            conList.RemoveAll(con => con.Child_Id == id);
            SaveToXML<List<Contract>>(conList, pathContract);//save contracts to file without those of children


            removeChildElement.Remove();//delete from root

            childRoot.Save(pathChild);//save to file
            return true;//stam
        }

        public void Update_Child(Child child1)
        {
            LoadDataChild();
            //find element of this child
            XElement updateChElement = (from chElement in childRoot.Elements()
                                        where int.Parse(chElement.Element("id").Value) == child1.Id
                                        select chElement).FirstOrDefault();

            if (updateChElement == null)//cant update child that doesnt exist
                throw new Exception("no such child");

            //put new values,it has reference to root
            updateChElement.Element("firstName").Value = child1.First_Name;
            updateChElement.Element("birthDate").Value = child1.Birth_Date.ToString();
            updateChElement.Element("isSpecialNeeds").Value = child1.Is_Special_Needs.ToString();
            updateChElement.Element("specialNeeds").Value = child1.Special_Needs;
            updateChElement.Element("isAllergy").Value = child1.Is_Allergy.ToString();
            updateChElement.Element("allergy").Value = child1.Allergy;
            updateChElement.Element("diapers").Value = child1.Without_Diapers.ToString();
            //save new to file
            childRoot.Save(pathChild);
        }


        #endregion

        #region contract
        public void Add_Contract(Contract contract1)
        {
            contract1.Num_Of_Contract = Contract.counter;
            Contract.counter++;//update num of contracts
            XElement help = XElement.Load("..//..//..//xmlFiles//config.xml");
            help.Element("counter").Value = Contract.counter.ToString();
            help.Save("..//..//..//xmlFiles//config.xml");


            List<Contract> conList = LoadFromXML<List<Contract>>(pathContract);//we are sure there is file cause created once in ctor
            conList.Add(contract1);//add
            SaveToXML<List<Contract>>(conList, pathContract);//save in file
        }

        public IEnumerable<Contract> GetAll_Contract(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)//if there isnt condition we return all list that was converted to enumerable from file
                return LoadFromXML<List<Contract>>(pathContract).AsEnumerable();
            return LoadFromXML<List<Contract>>(pathContract).Where(predicate);//return by condition
        }

        public Contract Get_Contract(int counter)
        {
            List<Contract> conList = LoadFromXML<List<Contract>>(pathContract);//we are sure there is file cause created once in ctor
           return conList.FirstOrDefault(con=>con.Num_Of_Contract==counter);//find wanted con and return him
           
        }

        public bool Remove_Contract(int counter)
        {
            Contract conToRemove = Get_Contract(counter);
            if (conToRemove == null)
                throw new Exception("no such contract");

            List<Contract> conList = LoadFromXML<List<Contract>>(pathContract);//we are sure there is file cause created once in ctor
            conList.RemoveAll(con=>con.Num_Of_Contract==counter);//delete
            SaveToXML<List<Contract>>(conList, pathContract);//save in file
            return true;
        }

        public void Update_Contract(Contract contract1)
        {
            List<Contract> conList = LoadFromXML<List<Contract>>(pathContract);//we are sure there is file cause created once in ctor
            int contract_Index = conList.FindIndex(con => con.Num_Of_Contract == contract1.Num_Of_Contract);//return index of wanted contract in list
            if (contract_Index == -1)//didnt find
                throw new Exception("no such contract");//cant update if contract doesnt exist
            conList[contract_Index] = contract1;//update contract in his place
            SaveToXML<List<Contract>>(conList, pathContract);//save in file after changes
        }

        #endregion

        #region mother

        public void Add_Mother(Mother mother1)
        {
            Mother mom = Get_Mother(mother1.Id);//check if this id already exits
            if (mom != null)//it means there is already such a mother
                throw new Exception("there is already a mother with the same id");

            List<Mother> momList = LoadFromXML<List<Mother>>(pathMother);//we are sure there is file cause created once in ctor
            momList.Add(mother1);
            SaveToXML<List<Mother>>(momList,pathMother);//save in file


        }

        public IEnumerable<Mother> GetAll_Mother(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)//if there isnt condition we return all list that was converted to enumerable from file
                return LoadFromXML<List<Mother>>(pathMother).AsEnumerable();
            return LoadFromXML<List<Mother>>(pathMother).Where(predicate);//return by condition
            
        }

        public Mother Get_Mother(int id)
        {
            return LoadFromXML<List<Mother>>(pathMother).FirstOrDefault(mom => mom.Id == id);
        }

        public bool Remove_Mother(int id)
        {
            Mother momToRemove = Get_Mother(id);
            if (momToRemove == null)//cant remove if doesnt exist
                throw new Exception("no such mother");
            //delete all of her children:

            List<Child> childList = Get_All_Children().ToList();
            for (int i = 0; i < childList.Count; i++)//passing all over the children and look for her chidren
            {
                if (childList[i].Mother_Id == id)//we find a son
                {
                    Remove_Child(childList[i].Id);//delete from file of children by our special func that also delete child's contracts
                    childList = Get_All_Children().ToList();
                    i = -1;//from the begining,because ++ will bring us to 0
                }
            }

            //delete herself:

            List<Mother> momList = LoadFromXML<List<Mother>>(pathMother);//we are sure there is file cause created once in ctor
            momList.RemoveAll(mom=>mom.Id==id);
            SaveToXML<List<Mother>>(momList, pathMother);//save in file without this mom

            return true;//stam

        }

        public void Update_Mother(Mother mother1)
        {
            List<Mother> momList = LoadFromXML<List<Mother>>(pathMother);//we are sure there is file cause created once in ctor
            int mother_Index = momList.FindIndex(mom => mom.Id == mother1.Id);//return index of wanted mother in list
            if (mother_Index == -1)//didnt find
                throw new Exception("no such mother");//cant update if mother doesnt exist
            momList[mother_Index] = mother1;//update mother in her place 
            SaveToXML<List<Mother>>(momList, pathMother);//save in file after changes
        }
        #endregion

        #region nanny


        public void Add_Nanny(Nanny nanny1)
        {
            Nanny nan = Get_Nanny(nanny1.Id);//check if this id already exits
            if (nan != null)//it means there is already such a nanny
                throw new Exception("there is already a nanny with the same id");

            List<Nanny> nanList = LoadFromXML<List<Nanny>>(pathNanny);
            nanList.Add(nanny1);
            SaveToXML<List<Nanny>>(nanList, pathNanny);
       
        }



        public IEnumerable<Nanny> GetAll_Nanny(Func<Nanny, bool> predicate = null)
        {
            if(predicate==null)
               return LoadFromXML<List<Nanny>>(pathNanny).AsEnumerable();
            return LoadFromXML<List<Nanny>>(pathNanny).Where(predicate);
        }


        public Nanny Get_Nanny(int id)
        {
            return LoadFromXML<List<Nanny>>(pathNanny).FirstOrDefault(nan=>nan.Id==id);
        }


        public bool Remove_Nanny(int id)
        {
            Nanny nan = Get_Nanny(id);
            if (nan == null)
                throw new Exception("no such nanny");//if there isnt nanny we cant remove her

            //delete all of nanny's contracts
           List<Contract> conList= GetAll_Contract().ToList();
            conList.RemoveAll(con => con.Nanny_Id == id);
            SaveToXML<List<Contract>>(conList,pathContract);//save contracts to file without those of nanny

            List<Nanny> nanList = LoadFromXML<List<Nanny>>(pathNanny);//we are sure there is file cause created once in ctor
            nanList.RemoveAll(nanny=>nanny.Id==id);
            SaveToXML<List<Nanny>>(nanList, pathNanny);//save in file without this nanny

            return true;//stam
        }

        public void Update_Nanny(Nanny nanny1)
        {
            List<Nanny> nanList = LoadFromXML<List<Nanny>>(pathNanny);
            int nanny_Index = nanList.FindIndex(nan => nan.Id == nanny1.Id);//return index of wanted nanny in list
            if (nanny_Index == -1)//didnt find
                throw new Exception("no such nanny");//cant update if nanny doesnt exist
            nanList[nanny_Index] = nanny1;//update nanny in her place 
            SaveToXML<List<Nanny>>(nanList,pathNanny);//save in file after changes
        }

        #endregion


    }
}
