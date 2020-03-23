using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    internal class Dal_imp : Idal
    {
        #region child_func
        public void Add_Child(Child child1)
        {
            Child ch = Get_Child(child1.Id);//check if this id already exits
            if (ch != null)//it means there is already such a child
                throw new Exception("there is already a child with the same id");
            DataSource.children_List.Add(child1);
        }

        public bool Remove_Child(int id)
        {
            Child ch = Get_Child(id);
            if (ch == null)
                throw new Exception("no such child");//if there isnt child we cant remove him
            DataSource.contracts_List.RemoveAll(con => con.Child_Id == id);//deletes all contracts with this child
            return DataSource.children_List.Remove(ch);//deletes kid from list of children
        }

        public void Update_Child(Child child1)
        {
            int child_Index = DataSource.children_List.FindIndex(ch => ch.Id == child1.Id);//return index of wanted child in list
            if (child_Index == -1)//didnt find
                throw new Exception("no such cuild");//cant update if child doesnt exist
            DataSource.children_List[child_Index] = child1;//update child in his place
        }

        public Child Get_Child(int id)
        {
            return DataSource.children_List.FirstOrDefault(c => c.Id == id);//go to static list and return a child,(FirstOrDefault is an extension method for ienumerable)
        }

        public IEnumerable<Child> Get_All_Children(Func<BE.Child, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.children_List.AsEnumerable();
            return DataSource.children_List.Where(predicate);
        }

        
        #endregion

        #region mother_func
        public void Add_Mother(Mother mother1)
        {
            Mother mom = Get_Mother(mother1.Id);//check if this id already exits
            if (mom != null)//it means there is already such a mother
                throw new Exception("there is already a mother with the same id");
            DataSource.mothers_List.Add(mother1);
        }


        public bool Remove_Mother(int id)
        {
            Mother mom = Get_Mother(id);
            if (mom == null)
                throw new Exception("no such mother");//if there isnt mother we cant remove her
            //var mother_Sons = Get_Children_By_Mom(id);//create a list with all of her children
            //DataSource.children_List.RemoveAll(ch => ch.Mother_Id == id);
            ////while (mother_Sons != null)//delets all of her children and their contracts
            ////{
            ////    Remove_Child(mother_Sons.First().Id);
            ////    (mother_Sons.AsEnumerable()).
            //////}
            //foreach (Child item in DataSource.children_List)//cant remove in for each cause it changes the collection
            //{
            //    if(item.Mother_Id==id)
            //       Remove_Child(item.Id);
            //}

           for(int i=0;i<DataSource.children_List.Count;i++)//passing all over the children and look for her chidren
            {
                if (DataSource.children_List[i].Mother_Id == id)//we find a son
                {
                    Remove_Child(DataSource.children_List[i].Id);//delete from list by our special func that also delete child's contracts
                    i=-1;//from the begining,because ++ will bring us to 0
                }
            }
            return DataSource.mothers_List.Remove(mom);//deletes mother from list of mothers
        }

        public void Update_Mother(Mother mother1)
        {
            int mother_Index = DataSource.mothers_List.FindIndex(mom => mom.Id == mother1.Id);//return index of wanted mother in list
            if (mother_Index == -1)//didnt find
                throw new Exception("no such mother");//cant update if mother doesnt exist
            DataSource.mothers_List[mother_Index] = mother1;//update mother in her place 
        }

        public Mother Get_Mother(int id)
        {
            return DataSource.mothers_List.FirstOrDefault(m => m.Id == id);//go to static list and return a mother,(FirstOrDefault is an extension method for ienumerable)
        }

        //public IEnumerable<Child> Get_Children_By_Mom(int Mother_id)can use predicat in get all children to return just her!!!
        //{
        //    Mother mom = Get_Mother(Mother_id);
        //    if (mom == null)//if there isnt mom so cant return her children
        //        throw new Exception("there isnt a mom with the this id");
        //    return DataSource.children_List.Where(c => c.Mother_Id == Mother_id);//returns all children of this mom
        //}

        public IEnumerable<Mother> GetAll_Mother(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)//if there isnt condition we return all list that was converted to enumerable
                return DataSource.mothers_List.AsEnumerable();
            return DataSource.mothers_List.Where(predicate);//return by condition
        }

        public IEnumerable<IGrouping<int, Child>> Get_Children_By_Mothers()
        {
            //returns groups of families
            return from item in DataSource.children_List
                   group item by item.Mother_Id;
        }
        #endregion

        #region nanny_func

        public void Add_Nanny(Nanny nanny1)
        {
            Nanny nan = Get_Nanny(nanny1.Id);//check if this id already exits
            if (nan!= null)//it means there is already such a nanny
                throw new Exception("there is already a nanny with the same id");
            DataSource.nannies_List.Add(nanny1);
        }

        public bool Remove_Nanny(int id)
        {
            Nanny nan = Get_Nanny(id);
            if (nan == null)
                throw new Exception("no such nanny");//if there isnt nanny we cant remove her
            DataSource.contracts_List.RemoveAll(con => con.Nanny_Id == id);//deletes all contracts with this nanny
            return DataSource.nannies_List.Remove(nan);//deletes nanny from list of nannies
        }

        public void Update_Nanny(Nanny nanny1)
        {
            int nanny_Index = DataSource.nannies_List.FindIndex(nan => nan.Id == nanny1.Id);//return index of wanted nanny in list
            if (nanny_Index == -1)//didnt find
                throw new Exception("no such nanny");//cant update if nanny doesnt exist
            DataSource.nannies_List[nanny_Index] = nanny1;//update nanny in her place 
        }

        public IEnumerable<Nanny> GetAll_Nanny(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)//if there isnt condition we return all list that was converted to enumerable
                return DataSource.nannies_List.AsEnumerable();
            return DataSource.nannies_List.Where(predicate);//return by condition
        }


        public Nanny Get_Nanny(int id)
        {
            return DataSource.nannies_List.FirstOrDefault(n => n.Id == id);//go to static list and return a nanny,(FirstOrDefault is an extension method for ienumerable)
        }





        #endregion

        #region contract_func
        public void Add_Contract(Contract contract1)
        {
            //dont have to check cause bl checked it before...

            //Child ch = Get_Child(contract1.Child_Id);
            //Nanny nan = Get_Nanny(contract1.Nanny_Id);

            //if (ch == null && nan == null)//if we dont know this nanny and child we cant make contract for them...
            //    throw new Exception("there arent nanny and a child with these details");
            //if (ch == null)//if we dont know this child we cant make contract for him...
            //    throw new Exception("there isnt a child with this id");
            //if (nan == null)//if we dont know this nanny we cant make contract for her...
            //    throw new Exception("there isnt a nanny with this id");

            //nanny and child exist:

            contract1.Num_Of_Contract = Contract.counter;
            Contract.counter++;//update num of contracts
            DataSource.contracts_List.Add(contract1);
        }

        public bool Remove_Contract(int counter)
        {
            Contract con = Get_Contract(counter);
            if (con == null)
                throw new Exception("no such contract");//if there isnt contract we cant remove him
            return DataSource.contracts_List.Remove(con);//deletes this contract from list of contracts

        }

        public void Update_Contract(Contract contract1)
        {
            int contract_Index = DataSource.contracts_List.FindIndex(con => con.Num_Of_Contract == contract1.Num_Of_Contract);//return index of wanted contract in list
            if (contract_Index == -1)//didnt find
                throw new Exception("no such contract");//cant update if contract doesnt exist
            DataSource.contracts_List[contract_Index] = contract1;//update contract in his place
        }

        public IEnumerable<Contract> GetAll_Contract(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)//if there isnt condition we return all list that was converted to enumerable
                return DataSource.contracts_List.AsEnumerable();
            return DataSource.contracts_List.Where(predicate);//return by condition
        }

        

        public Contract Get_Contract(int counter)
        {
            return DataSource.contracts_List.FirstOrDefault(c => c.Num_Of_Contract == counter);//go to static list and return a contract,(this is an extension method for ienumerable)
        }

       
        #endregion
    }
}
