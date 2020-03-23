using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;


namespace BL
{
    internal class BL_imp : IBL
    {
        DAL.Idal my_dal ;
        public BL_imp()
        {
            my_dal = DAL.FactoryDall.GetDal();
            //init();
        }

      //void init()
        //{
        //    Nanny nan1 = new Nanny()
        //    {
        //        Id = 111111111,
        //        Family_Name = "choen",
        //        First_Name = "rachel",
        //        Birth_Date = new DateTime(1996, 01, 01),
        //        Phone_Number = 123,
        //        Country = "isreal",
        //        City = "metula",
        //        Street = "halevanon",
        //        Elevator = true,
        //        Floor = 5,
        //        Years_Experience = 3,
        //        Max_Children = 2,
        //        Min_Kid_Age = 4,
        //        Max_Kid_Age = 24,
        //        Is_Hour_Salary = true,
        //        Hour_Salary=20,
        //        Month_Salary = 1000,
        //        Vacation_By_Education = true,
        //        Vacation_By__Tmt = false,
        //        Recommendations = "very good",
        //        Is_Religious = true,
        //        Is_OutDoors = false,
        //        Comfort_With_Pets = false,
        //        Smoking = true,
        //        Gives_Food = true
        //    };
        //    nan1.Work_Day[(int)Days.Sunday] = true;
        //    nan1.Work_Hours[0, 0] = new DateTime(2000, 01, 01, 10, 00, 00);
        //    nan1.Work_Hours[1, 0] = new DateTime(2000, 01, 01, 13, 00, 00);
        //    nan1.Spoken_Languages[(int)Languages.Hebrew] = true;
        //    nan1.Spoken_Languages[(int)Languages.Yiddish] = true;
        //    Add_Nanny(nan1);
        //    Nanny nan2 = new Nanny()
        //    {
        //        Id = 222222222,
        //        Family_Name = "choen",
        //        First_Name = "shira",
        //        Birth_Date = new DateTime(1990, 01, 01),
        //        Phone_Number = 456,
        //        Country = "isreal",
        //        City = "metula",
        //        Street = "halevanon",
        //        Elevator = false,
        //        Floor = 3,
        //        Years_Experience = 1,
        //        Max_Children = 2,
        //        Min_Kid_Age = 2,
        //        Max_Kid_Age = 24,
        //        Is_Hour_Salary = true,
        //        Hour_Salary = 30,
        //        Month_Salary = 800,
        //        Vacation_By_Education = true,
        //        Vacation_By__Tmt = false,
        //        Recommendations = "very good",
        //        Is_Religious = false,
        //        Is_OutDoors = false,
        //        Comfort_With_Pets = false,
        //        Smoking = false,
        //        Gives_Food = false
        //    };
        //    nan2.Work_Day[(int)Days.Monday] = true;
        //    nan2.Work_Day[(int)Days.Tuesday] = true;
        //    nan2.Work_Hours[0, 1] = new DateTime(2000, 01, 01, 08, 00, 00);
        //    nan2.Work_Hours[1, 1] = new DateTime(2000, 01, 01, 13, 00, 00);
        //    nan2.Work_Hours[0, 2] = new DateTime(2000, 01, 01, 10, 00, 00);
        //    nan2.Work_Hours[1, 2] = new DateTime(2000, 01, 01, 14, 00, 00);
        //    nan2.Spoken_Languages[(int)Languages.Hebrew] = true;
        //    nan2.Spoken_Languages[(int)Languages.English] = true;
        //    Add_Nanny(nan2);
        //    Mother mom = new Mother()
        //    {
        //        Id = 333333333,
        //        Family_Name = "lev",
        //        First_Name = "sheli",
        //        Phone_Number = 111,
        //        Home_Country = "isreal",
        //        Home_City = "metula",
        //        Home_Street = "halevanon",
        //        Min_Years_Experience = 1,
        //        Want_Hour_Salary = true,
        //        Food_From_Nanny = true,
        //        Take_By_Car = true,
        //        Religious_Nanny = true,
        //        Smoking_Nanny = true,
        //        Comments = "hello"
        //    };
        //    mom.Wanted_Days[(int)Days.Monday] = true;
        //    mom.Wanted_Hours[0, 1] = new DateTime(2000, 01, 01, 11, 00, 00);
        //    mom.Wanted_Hours[1, 1] = new DateTime(2000, 01, 01, 12, 30, 00);
        //    Add_Mother(mom);
        //    Mother mom2 = new Mother()
        //    {
        //        Id = 444444444,
        //        Family_Name = "levi",
        //        First_Name = "shira",
        //        Phone_Number = 333,
        //        Home_Country = "isreal",
        //        Home_City = "Yafo",
        //        Home_Street = "bbb",
        //        Min_Years_Experience = 2,
        //        Food_From_Nanny = false,
        //        Want_Hour_Salary = false,
        //        Take_By_Car = false,
        //        Religious_Nanny = false,
        //        Smoking_Nanny = true,
        //        Comments = "hello"
        //    };
        //    mom2.Wanted_Days[(int)Days.Sunday] = true;
        //    mom2.Wanted_Hours[0, 0] = new DateTime(2000, 01, 01, 11, 00, 00);
        //    mom2.Wanted_Hours[1, 0] = new DateTime(2000, 01, 01, 12, 30, 00);
        //    Add_Mother(mom2);
        //    Add_Child(new Child()
        //    {
        //        Id = 555555555,
        //        First_Name = "bobi",
        //        Mother_Id = 444444444,
        //        Birth_Date = new DateTime(2017, 01, 01),
        //        Allergy = "milk",
        //        Without_Diapers = true
        //    });

        //    Add_Child(new Child()
        //    {
        //        Id = 666666666,
        //        First_Name = "shimshon",
        //        Mother_Id = 333333333,
        //        Birth_Date = new DateTime(2016, 01, 01),
        //        Without_Diapers = true
        //    });


        //    Add_Child(new Child()
        //    {
        //        Id = 777777777,
        //        First_Name = "ori",
        //        Mother_Id = 333333333,
        //        Birth_Date = new DateTime(2017, 11, 01),
        //        Without_Diapers = true
        //    });

        //    Add_Contract(new Contract()
        //    {
        //        Nanny_Id = 111111111,
        //        Child_Id = 666666666,
        //        Meeting = true,
        //        Contract_Was_Signed = true,
        //        Is_Month_Salary = false,
        //        Hour_Salary = Get_Nanny(111111111).Hour_Salary
        //    });




        //}

        #region child_func
        public void Add_Child(Child child1)
        {
            Mother mom = Get_Mother(child1.Mother_Id);
            if (mom == null)//didnt find his mom
                throw new Exception("cant be child without mother");

            int age = (DateTime.Now.Subtract(child1.Birth_Date).Days);//we make minus between now and birth date and take all the days that she lives
            if (age < 0)
                throw new Exception("wrong birth date");

            my_dal.Add_Child(child1);

        }

        public bool Remove_Child(int id)
        {
            return my_dal.Remove_Child(id);
        }

        public void Update_Child(Child child1)
        {
            my_dal.Update_Child(child1);
        }

        public IEnumerable<Child> Get_All_Children(Func<BE.Child, bool> predicate = null)
        {
            return my_dal.Get_All_Children(predicate);
        }

        public Child Get_Child(int id)
        {
            return my_dal.Get_Child(id);
        }

        //public IEnumerable<IGrouping<int, Child>> Get_Children_By_Mothers()
        //{
        //    return my_dal.Get_Children_By_Mothers();
        //}
    
        public IEnumerable<Child> children_without_nanny()
        {
            return Get_All_Children(without_nanny_predicate);//return all of the children that dont have nanny
        }


        public bool without_nanny_predicate(Child ch)
        {
            int id = ch.Id;
            var contracts_of_child = GetAll_Contract(con => con.Child_Id == id);
            if (contracts_of_child.Count()==0)//this child doesnt have any contract
                return true;
            return false;
        }
        #endregion child_func

        #region mother_func
        public void Add_Mother(Mother mother1)
        {
            for (int i = 0; i < 7; i++)//check end isnt smaller then begining
            {
                if (mother1.Wanted_Hours[1, i] < mother1.Wanted_Hours[0, i])
                    throw new Exception("wrong hours format");
            }
            my_dal.Add_Mother(mother1);
        }

        public bool Remove_Mother(int id)
        {
            return my_dal.Remove_Mother(id);
        }

        public void Update_Mother(Mother mother1)
        {
            my_dal.Update_Mother(mother1);
        }

        public IEnumerable<Mother> GetAll_Mother(Func<Mother, bool> predicate = null)
        {
            return my_dal.GetAll_Mother(predicate);
        }


        public Mother Get_Mother(int id)
        {
            return my_dal.Get_Mother(id);
        }

       
        #endregion mother_func

        #region nanny_func
        public void Add_Nanny(Nanny nanny1)
        {
            int age = (DateTime.Now.Subtract(nanny1.Birth_Date).Days);//we make minus between now and birth date and take all the days that she lives
            if (age / 365 < 18)
                throw new Exception("cant add nanny less then 18 years");
            for (int i = 0; i < 7; i++)//check end isnt smaller then begining
            {
                if (nanny1.Work_Hours[1, i] < nanny1.Work_Hours[0, i])
                    throw new Exception("wrong hours format");
            }
            my_dal.Add_Nanny(nanny1);
        }

        public bool Remove_Nanny(int id)
        {
            return my_dal.Remove_Nanny(id);
        }

        public void Update_Nanny(Nanny nanny1)
        {
            my_dal.Update_Nanny(nanny1);
        }

        public IEnumerable<Nanny> GetAll_Nanny(Func<Nanny, bool> predicate = null)
        {
            return my_dal.GetAll_Nanny(predicate);
        }

        public Nanny Get_Nanny(int id)
        {
            return my_dal.Get_Nanny(id);
        }

        #endregion nanny_func

        #region contract_func
        public void Add_Contract(Contract contract1)
        {
            //check that this child hasnt existed in this nanny already
            if (GetAll_Contract(con => con.Nanny_Id == contract1.Nanny_Id && con.Child_Id == contract1.Child_Id).Count() != 0)
                throw new Exception("this contract has allready been in system");


            Child ch = Get_Child(contract1.Child_Id);
            if (ch == null)//cant add contract without child
                throw new Exception("child in contract doesnt exist");

            int age_in_days = (DateTime.Now.Subtract(ch.Birth_Date).Days);//we make minus between now and birth date and take all the days that he lives
            if (age_in_days / 30 < 3)
                throw new Exception("cant add to contract,child that is less then 3 monthes");

            Nanny nan = Get_Nanny(contract1.Nanny_Id);
            if (nan == null)//cant add contract without nanny
                throw new Exception("nanny in contract doesnt exist");



            var nanny_contracts = GetAll_Contract(con => con.Nanny_Id == nan.Id);//return all previous contracts of this nanny
            int sum = 0;
            foreach (var item in nanny_contracts)//counts all of this nanny's contracts
            {
                sum++;
            }
            if (sum == nan.Max_Children)//shr took her max
                throw new Exception("this nanny cant take more children");
            if(age_in_days/30<nan.Min_Kid_Age|| age_in_days / 30 > nan.Max_Kid_Age)//if age of child isnt in range of allowed ages for this nan
                throw new Exception("this nanny cant take this age of child");

            Calculate_Salary(contract1, nan, ch);//activate func that puts in the correct salary
            my_dal.Add_Contract(contract1);

        }

        public bool Remove_Contract(int counter)
        {
            return my_dal.Remove_Contract(counter);
        }

        public void Update_Contract(Contract contract1)
        {
            my_dal.Update_Contract(contract1);
        }

        public IEnumerable<Contract> GetAll_Contract(Func<Contract, bool> predicate = null)
        {
            return my_dal.GetAll_Contract(predicate);
        }

        public Contract Get_Contract(int counter)
        {
            return my_dal.Get_Contract(counter);
        }


        #endregion contract_func

        #region calculates_and_more

        public void Calculate_Salary(Contract con, Nanny nan, Child ch)
        {
            int sum = 0;
            Child help;
            var nanny_contracts = GetAll_Contract(co => co.Nanny_Id == nan.Id);//return all contracts of this nanny
            foreach (var item in nanny_contracts)//sum number of brothers in this nanny 
            {
                help = Get_Child(item.Child_Id);
                if (help.Mother_Id == ch.Mother_Id&&help.Id!=ch.Id)//find same mom ,so they are brothers,and itisnt himself
                    sum++;
            }

            if (con.Is_Month_Salary == true)//calculate per month
            {
                double salary = con.Month_Salary;
                salary = salary * ((100 - 2 * (sum)) / 100);//Two percent discount on each additional brother
                con.Month_Salary = salary;
                return;
            }
            ///per hour
            double sum_hours = 0;
            Mother mom = Get_Mother(ch.Mother_Id);
            for (int i = 0; i < 7; i++)//sums all hours that mother gives her baby in the week
            {
                if(mom.Wanted_Days[i]==true)
                   sum_hours += (mom.Wanted_Hours[1, i].Subtract(mom.Wanted_Hours[0, i])).TotalHours;
            }
            sum_hours *= 4;//all hours in month
            double salary1 = con.Hour_Salary * sum_hours;//before discount
            salary1 = (salary1 * (100 - 2 * (sum))) / 100;//Two percent discount on each additional brother
            con.Month_Salary = salary1;

        }

        public static float CalculateDistance(string source, string dest)//google maps
        {
           
            var drivingDirectionRequest = new DirectionsRequest
            { TravelMode = TravelMode.Walking, Origin = source, Destination = dest };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        public IEnumerable<Nanny> find_nanny_byTime(int mom_id)
        {
            Mother mom = Get_Mother(mom_id);
            if (mom == null)
                throw new Exception("this mom didnt register");
            var v = from item in GetAll_Nanny()
                    where check__matchTime(item, mom_id)
                    select item;
            if (v.Count()!=0)//we find the best match/matches
                return v;
            return close__matchTime(mom_id);

        }

        public bool check__matchTime(Nanny nan, int mother_id)
        {
            Mother mom = Get_Mother(mother_id);
            for (int i = 0; i < 7; i++)//check match in days of the week
            {
                if (mom.Wanted_Days[i] == true && nan.Work_Day[i] == false)//mother needs this day but nanny doesnt work
                    return false;
            }
            for (int i = 0; i < 7; i++)//check match in hours of the days
            {
                if (mom.Wanted_Days[i] == true && (nan.Work_Hours[0, i] > mom.Wanted_Hours[0, i]))//mom needs this day but nanny begins too late
                    return false;
                if (mom.Wanted_Days[i] == true && (nan.Work_Hours[1, i] < mom.Wanted_Hours[1, i]))//mom needs this day but nanny finish too early
                    return false;
            }
            return true;
        }

        public IEnumerable<Nanny> close__matchTime(int mother_id) 
        {
            var nannyList = GetAll_Nanny();
            if (nannyList.Count() <= 5)//we have to return the five closet nanies so if we dont have more then five we just return all of them
                return nannyList;


            List<Match> closeMatch = new List<Match>();//this is list of all nanies with their differences,we are going to fill it,sort and return the top five
            Mother mom = Get_Mother(mother_id);


            foreach (Nanny item in nannyList)//passing on all the nanny list and check match for every nanny
            {
                int sum_difference_day = 0;//sum all days that mom wants but nanny doesnt work
                double sum_difference_hours = 0;//sum in all of the days that nanny works and mother wants,what are the differences hours of  morning and afternoon

                for (int i = 0; i < 7; i++)//check match in days of the week
                {
                    if (mom.Wanted_Days[i] == true && item.Work_Day[i] == false)//mother needs this day but nanny doesnt work
                        sum_difference_day++;
                }

                for (int i = 0; i < 7; i++)//check match in hours of the days
                {
                    if (mom.Wanted_Days[i] == true && item.Work_Day[i] == true)//sums difeerence hours just in days that mom gives the baby
                    {
                        if (item.Work_Hours[0, i] > mom.Wanted_Hours[0, i])//difference in morning(too late)
                            sum_difference_hours += item.Work_Hours[0, i].Subtract(mom.Wanted_Hours[0, i]).TotalHours;
                        if (item.Work_Hours[1, i] < mom.Wanted_Hours[1, i])//difference in noon(too early)
                            sum_difference_hours += mom.Wanted_Hours[1, i].Subtract(item.Work_Hours[1, i]).TotalHours;
                    }

                }

                Match toAdd = new Match() { nan = item, day_difference = sum_difference_day, hour_difference = sum_difference_hours };
                closeMatch.Add(toAdd);
            }

            closeMatch.Sort();//sort accordig to best match
            closeMatch.RemoveRange(5, closeMatch.Count - 5);//leaves just 5 min items in list
            var v = from item in closeMatch//v includes the top five nannies
                    select item.nan;
            return v;


        }

        public IEnumerable<Nanny> match_byKM(int mother_id)
        {
            float km;//this is the max distance that mom agree
            Mother mom = Get_Mother(mother_id);
            if (mom == null)//didnt find mom
                throw new Exception("this mom didnt register");
            string home_source = mom.Home_Street + "," + mom.Home_City + "," + mom.Home_Country;//adress of mom

            if (mom.Wanted_Street == null || mom.Wanted_City == null || mom.Wanted_Country == null)//if mom didnt fill all wanted adress
            {
                if (mom.Take_By_Car == true)//we decided that by car 10 km is the max
                    km = 10;
                else//we decided that by leg 1 km is the max
                    km = 1;
            }
            else
            {
                string wanted_destinition = mom.Wanted_Street + "," + mom.Wanted_City + "," + mom.Wanted_Country;
                km = CalculateDistance(home_source, wanted_destinition);//this is the wanted max distance
              
            }

            return GetAll_Nanny(nan => CalculateDistance(home_source, nan.Street + "," + nan.City + "," + nan.Country) <= km);


        }

        public IEnumerable<Nanny> vacation_TMT()
        {
            return GetAll_Nanny(nan => nan.Vacation_By__Tmt == true); //gives all nanny by tmt     
        }

        public int num_condition_contracts(Func<Contract, bool> predicate = null)
        {
            return (GetAll_Contract(predicate)).Count();//counts all contracts that are matching to this condition
        }

        public IEnumerable<IGrouping<int, Nanny>> nannies_by_children_age(bool by_max_age, bool sort = false)//each group contains all nanny that begin/end to take baby in same month
        {
            IEnumerable<IGrouping<int, Nanny>> nannies_age_groups;
            if (by_max_age == true)//the key of each group is the max age that nannies let
            {
                nannies_age_groups = from item in GetAll_Nanny()
                                     group item by item.Max_Kid_Age;
            }
            else//the key of each group is the min age that nannies let
            {
                nannies_age_groups = from item in GetAll_Nanny()
                                     group item by item.Min_Kid_Age;
            }
            if (sort == true)//we sort groups by the key 
            {
                return from item in nannies_age_groups
                       orderby item.Key
                       select item;
            }
            return nannies_age_groups;
        }

        public IEnumerable<IGrouping<int, Contract>> contracts_by_km(bool sort = false)//each group contains all contracts in range of (group.key*5) km to (group.key*5+5) km
        {
            return from item in GetAll_Contract()
                   group item by (getDistance(item) / 1000);
        }

        public int getDistance(Contract con)//distance between mom and nanny
        {
            Mother mom = Get_Mother((Get_Child(con.Child_Id).Mother_Id));
            Nanny nan = Get_Nanny(con.Nanny_Id);
            string nanny_adress = nan.Street + "," + nan.City + "," + nan.Country;
            if (mom.Wanted_Street==null || mom.Wanted_City==null|| mom.Wanted_Country==null)//mom didnt fill what is wanted adress so we calculate from her home
            {
                string mom_home = mom.Home_Street + "," + mom.Home_City + "," + mom.Home_Country;
                return (int)CalculateDistance(mom_home, nanny_adress);
            }
            //calculates distance between wanted adress and nanny adress
            string wanted_destinition = mom.Wanted_Street + "," + mom.Wanted_City + "," + mom.Wanted_Country;
            return (int)CalculateDistance(wanted_destinition, nanny_adress);
        }

        public IEnumerable<Child> children_of_nanny(int nanny_id)
        {
         return from item in GetAll_Contract(con => con.Nanny_Id == nanny_id)//pass on all contracts of nanny and add child from each contract
         select Get_Child(item.Child_Id);
        }

        public string birthdays_in_nanny(int nanny_id)//return string contains all birhdays of children in nanny
        {
            string birthdays_in_nanny=null;
            //creates a list of all birthdates of children in this nanny order by the monthes
            var birthdays= from item in children_of_nanny(nanny_id)
                           orderby item.Birth_Date.Month
                           select new { child_name = item.First_Name, child_id = item.Id, birthday = item.Birth_Date.ToShortDateString() };
            foreach (var item in birthdays)
            {
                birthdays_in_nanny += "name: " + item.child_name + "    id: " + item.child_id + "    birthdate:" + item.birthday + "\n";
            }
            return birthdays_in_nanny;
        }

        public string phonebook_for_nanny(int nanny_id)//return string contains all phones of mothers of children in nanny
        {
            
            string phonebook_for_nanny = null;
            //creates a list of all phones of mothers of children in this nanny order by the names
            var phonebook = from item in children_of_nanny(nanny_id)
                            let mom = Get_Mother(item.Mother_Id)//we are going to use mom five times so we find it just once by let
                            orderby item.First_Name
                            select new { child_first_name = item.First_Name, child_family_name = mom.Family_Name, child_mom_name =mom.First_Name,phone=mom.Phone_Number,adress=mom.Home_City+" "+mom.Home_Street };
            int index = 1;
            foreach (var item in phonebook)
            {
                phonebook_for_nanny += index+": child name: " + item.child_first_name + "    family name: " + item.child_family_name + "    mother name: " + item.child_mom_name+ "    phone: "+item.phone+ "    adress: "+item.adress+"\n";
                index++;
            }
            return phonebook_for_nanny;
            
        }

        public string phonebook_for_mother(int child_id)//return string contains all phones of children in my child Kindergarten and his nanny
        {
            //create list of all nannies of my child like those of mornings and those of nights
           var all_child_nannies= from item in GetAll_Contract(con => con.Child_Id == child_id)
            select Get_Nanny(item.Nanny_Id);

            string phonebook_for_mother = null;
            char index = 'a';
            foreach (var item in all_child_nannies)//pass on each nanny of my child and prints her details and her children details
            {
                phonebook_for_mother += index+ ": nanny name: " + item.First_Name + " " + item.Family_Name + "    phone: " + item.Phone_Number + "    adress:" + item.City + " " + item.Street+"\n";
                phonebook_for_mother += phonebook_for_nanny(item.Id);
                phonebook_for_mother += "\n";
                index++;
            }
            return phonebook_for_mother;
        }

        public string all_allergies_in_nanny(int nanny_id)//return for nanny all the allergic children and their allergies
        {
            string all_allergies_in_nanny = null;
            foreach (Child item in children_of_nanny(nanny_id))
            {
                if (item.Is_Allergy == true)//this child is allergic
                    all_allergies_in_nanny += "child name: " + item.First_Name + "    allergic to: " + item.Allergy + "\n";
            }
            return all_allergies_in_nanny;
        }

        public string phones_for_recommendations(string nanny_name,string nanny_family_name)//mom gives name of nanny and get all phones of mothrs of this nanny,good for asking recommendations
        {
            var wanted_nannies=GetAll_Nanny(nan => nan.First_Name == nanny_name && nan.Family_Name == nanny_family_name);//get all nannies with the wanted name
            if (wanted_nannies.Count() == 0)
                throw new Exception("this nanny doesnt exist");
            string phones_for_recommendations = null;
            char index = 'a';
            foreach (Nanny item in wanted_nannies)//pass on each nanny of wanted and prints her details and her children details
            {
                phones_for_recommendations += index+ ": nanny name: " + item.First_Name + " " + item.Family_Name + "    phone: " + item.Phone_Number + "    adress:" + item.City + " " + item.Street + "\n";
                phones_for_recommendations += "These are all phone numbers for recommendations: \n";
                phones_for_recommendations += phonebook_for_nanny(item.Id);
                phones_for_recommendations += "\n";
                index++;
            }
            return phones_for_recommendations;
        }

        public IEnumerable<Nanny> best_match(int mom_id)
        {
            Mother mom = Get_Mother(mom_id);
            if (mom == null)//kind of exception for identify this problem
                throw new ApplicationException("cant find this mom");

            var match_time = find_nanny_byTime(mom_id);
            var match_distance = match_byKM(mom_id);
            var time_distance = match_time.Intersect(match_distance);//find common nannies
            if (time_distance.Count() == 0)//no intersection of all these conditions so return by previous conditions
                return match_time;

            var time_distance_religious = time_distance.Intersect(GetAll_Nanny(nan => nan.Is_Religious == mom.Religious_Nanny));
            if (time_distance_religious.Count()==0)//no intersection of all these conditions so return by previous conditions
                return time_distance;
            var time_distance_religious_isHourSalary = time_distance_religious.Intersect(GetAll_Nanny(delegate (Nanny nan) { if (nan.Is_Hour_Salary == false && mom.Want_Hour_Salary == true) return false; else return true; }));//we use anonymous delegate cause we have a condition that it is false just when mom wants by hour but nanny doesnt let
            if (time_distance_religious_isHourSalary.Count() == 0)//no intersection of all these conditions so return by previous conditions
                return time_distance_religious;
            var time_distance_religious_isHourSalary_smoking= time_distance_religious_isHourSalary.Intersect(GetAll_Nanny(delegate (Nanny nan) { if (nan.Smoking == true && mom.Smoking_Nanny == false) return false; else return true; }));//we use anonymous delegate cause we have a condition that it is false just when mom doesnt want smoking but nanny smokes
            if (time_distance_religious_isHourSalary_smoking.Count() == 0)//no intersection of all these conditions so return by previous conditions
                return time_distance_religious_isHourSalary;
            var time_distance_religious_isHourSalary_smoking_food = time_distance_religious_isHourSalary.Intersect(GetAll_Nanny(delegate (Nanny nan) { if (nan.Gives_Food== false && mom.Food_From_Nanny == true) return false; else return true; }));//we use anonymous delegate cause we have a condition that it is false just when mom wants food but nanny doesnt give
            if (time_distance_religious_isHourSalary_smoking_food.Count() == 0)//no intersection of all these conditions so return by previous conditions
                return time_distance_religious_isHourSalary_smoking;
            var time_distance_religious_isHourSalary_smoking_food_experience = time_distance_religious_isHourSalary.Intersect(GetAll_Nanny(nan => nan.Years_Experience >= mom.Min_Years_Experience));
            if (time_distance_religious_isHourSalary_smoking_food_experience.Count() == 0)//no intersection of all these conditions so return by previous conditions
                return time_distance_religious_isHourSalary_smoking_food;
            return time_distance_religious_isHourSalary_smoking_food_experience;//best match
        }

        #endregion calculates_and_more

    }
}
