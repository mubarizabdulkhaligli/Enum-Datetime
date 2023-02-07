using System;

namespace task
{
	class Program
	{
		static void Main(string[] args)
		{

			Group[] groups = new Group[0];

			string click;
			do
			{
				Console.WriteLine("\n===== MENU =====\n");

				Console.WriteLine("1. Create new group");
				Console.WriteLine("2. Show all groups");
				Console.WriteLine("3. Show groups by type");
                Console.WriteLine("4. Show started groups");
                Console.WriteLine("5. Show started groups(from last 2 months)");
                Console.WriteLine("6. Show groups (That will start to the end of this month)");
                Console.WriteLine("7. Show groups (from this date to this date)");
                Console.WriteLine("0. Quit");

				Console.Write("\nPlease select: ");
				click = Console.ReadLine();


				switch (click)
				{
					case "1":
						string GroupNo;
                        do
						{
                            Console.WriteLine("Group No: ");
                            GroupNo = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(GroupNo));
                        

                        
						string GroupTypeStr;
						byte GroupTypeByte;
						do
						{

							Console.WriteLine("Group Type: ");
							foreach (var item in Enum.GetValues(typeof(GroupType)))
								Console.WriteLine($"{(byte)item} - {item}");

							GroupTypeStr = Console.ReadLine();

						} while (string.IsNullOrWhiteSpace(GroupTypeStr) || !byte.TryParse(GroupTypeStr, out GroupTypeByte) || GroupTypeByte > 3 || GroupTypeByte < 0) ;
                        
						GroupType GroupType = (GroupType)GroupTypeByte;

						string startDateStr;

						DateTime startDate;
                        do
						{
                            Console.WriteLine("Start Date (month-day-year): ");
                            startDateStr = Console.ReadLine();

                        } while (!DateTime.TryParse(startDateStr, out startDate) || string.IsNullOrWhiteSpace(startDateStr));

                        Group group = new Group();

                        group.No = GroupNo;
                        group.Type = GroupType;
                        group.StartDate = startDate;

						Array.Resize(ref groups, groups.Length + 1);
						groups[groups.Length - 1] = group;
                        break;

					case "2":
						foreach (var item in groups)
						{
							Console.WriteLine($"No: {item.No}; Type: {item.Type}; StartDate: {item.StartDate.ToString("dd-MM-yyyy")}");
						}
						break;

					case "3":
                        do
                        {

                            Console.WriteLine("Group Type: ");
                            foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");

                            GroupTypeStr = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(GroupTypeStr) || !byte.TryParse(GroupTypeStr, out GroupTypeByte) || GroupTypeByte > 3 || GroupTypeByte < 0);

                        GroupType = (GroupType)GroupTypeByte;

                        foreach (var item in groups)
						{
							if (item.Type==GroupType)
							{
                                Console.WriteLine($"No: {item.No}; Type: {item.Type}; StartDate: {item.StartDate.ToString("dd-MM-yyyy")}");
                            }
						}
						break;

					case "4":

						foreach (var item in groups)
						{
							if (item.StartDate<DateTime.Now)
							{
                                Console.WriteLine($"No: {item.No}; Type: {item.Type}; StartDate: {item.StartDate.ToString("dd-MM-yyyy")}");
                            }
						}

                        break;

					case "5":
						
						foreach (var item in groups)
						{
							if (item.StartDate>DateTime.Now.AddMonths(-2) && item.StartDate<DateTime.Now)
							{
                                Console.WriteLine($"No: {item.No}; Type: {item.Type}; StartDate: {item.StartDate.ToString("dd-MM-yyyy")}");
                            }
						}
                        break;

					case "6":

						foreach (var item in groups)
						{
							if (item.StartDate>DateTime.Now && item.StartDate.Month==DateTime.Now.Month)
							{
                                Console.WriteLine($"No: {item.No}; Type: {item.Type}; StartDate: {item.StartDate.ToString("dd-MM-yyyy")}");
                            }
                        }
                        break;

					case "7":

						string dateInputStr1;
						DateTime dateInput1;
						do
						{
							Console.WriteLine("First Date (month-day-year): ");
							dateInputStr1 = Console.ReadLine();

						} while (!DateTime.TryParse(dateInputStr1, out dateInput1) || string.IsNullOrWhiteSpace(dateInputStr1) || dateInput1>DateTime.Now);

						string dateInputStr2;
						DateTime dateInput2;
						do
						{
							Console.WriteLine("Second Date (month-day-year): ");
							dateInputStr2 = Console.ReadLine();
						} while (!DateTime.TryParse(dateInputStr2, out dateInput2) || string.IsNullOrWhiteSpace(dateInputStr2) || dateInput2>DateTime.Now);

						foreach (var item in groups)
						{
							if (item.StartDate>dateInput1 && item.StartDate<dateInput2)
							{
                                Console.WriteLine($"No: {item.No}; Type: {item.Type}; StartDate: {item.StartDate.ToString("dd-MM-yyyy")}");
                            }
                        }
                        break;

					case "0":
						Console.WriteLine("You exited the program");
						break;
					default:
						Console.WriteLine("\nWrong entry, please select an option between 0 to 7\n");
						break;
				}

			} while (click!="0");
        }

	}
}

