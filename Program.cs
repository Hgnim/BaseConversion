namespace loe
{
	
	class Program
	{		
		static void Main(string[] args)
		{
			string[] type=new string[2];
			string inputStr;
			BaseConvert bc=new BaseConvert();
			while (true)
			{
				Console.Write("进制转换模式：");
				inputStr=Console.ReadLine();
				if(inputStr=="exit"){break;}
				else
				{
					type=inputStr.Split("-");
					string? inputNum;
					while (true)
					{
						Console.Write(type[0] + "-" + type[1] +" 输入：");
						inputNum=Console.ReadLine();
						if(inputNum=="back"){break;}
						else if(inputNum=="exit"){goto exitProgram;}
						else
						{					
							int baseInt=-1;
							try
							{
								switch (type[0])
								{
									case "d":
										switch (type[1])
										{
											case "b":
												baseInt=2;
												break;
											case "o":
												baseInt=8;
												break;
											case "d":
												baseInt=10;
												break;
											case "h":
												baseInt=16;
												break;
										}
										//if(baseInt!=-1){Console.WriteLine("输出：" + Convert.ToString(Convert.ToInt32(inputNum),baseInt).ToString());}
										if(baseInt!=-1){Console.WriteLine("输出：" + bc.BC(10,baseInt,inputNum));}
										break;
									case "b":
										switch (type[1])
										{
											case "b":
												baseInt=2;
												break;
											case "o":
												baseInt=8;
												break;
											case "d":
												baseInt=10;
												break;
											case "h":
												baseInt=16;
												break;
										}
										//if(baseInt!=-1){Console.WriteLine("输出：" + Convert.ToString(Convert.ToInt32(inputNum,2),baseInt));}
										if(baseInt!=-1){Console.WriteLine("输出：" + bc.BC(2,baseInt,inputNum));}
										break;
									case "o":
										switch (type[1])
										{
											case "b":
												baseInt=2;											
												break;
											case "o":
												baseInt=8;
												break;
											case "d":
												baseInt=10;
												break;
											case "h":
												baseInt=16;
												break;
										}
										//if(baseInt!=-1){Console.WriteLine("输出：" + Convert.ToString(Convert.ToInt32(inputNum,8),baseInt));}
										if(baseInt!=-1){Console.WriteLine("输出：" + bc.BC(8,baseInt,inputNum));}
										break;
									case "h":
										switch (type[1])
										{
											case "b":
												baseInt=2;
												break;
											case "o":
												baseInt=8;
												break;
											case "d":
												baseInt=10;
												break;
											case "h":
												baseInt=16;
												break;
										}
										if(baseInt!=-1){Console.WriteLine("输出：" + bc.BC(16,baseInt,inputNum));}
										break;
								}

							}catch{baseInt=-1;}
							finally{if(baseInt==-1){Console.WriteLine("输入错误！");}}
						}
					}
				}
			}
exitProgram:;
		}
	}
	class BaseConvert
	{
		public string BC(int inputBaseInt=-1,int outputBaseInt=-1,string inputStr="")
		{
			if(inputStr.IndexOf(".")!=-1)
			{
				if(outputBaseInt==10)
				{return BConvert(inputBaseInt,outputBaseInt,inputStr);}
				else if(inputBaseInt==10)
				{return BConvert(inputBaseInt,outputBaseInt,inputStr);}
				else
				{
					string runStr=inputStr;
					runStr=BConvert(inputBaseInt,10,runStr);
					return BConvert(10,outputBaseInt,runStr);
				}
			}
			else
			{
				return BConvert(inputBaseInt,outputBaseInt,inputStr);
			}
		}
		private string BConvert(int inputBaseInt=-1,int outputBaseInt=-1,string inputStr="")
		{
			if(inputStr.IndexOf(".")!=-1)
			{
				string[] inputStrSplit;
				string outputStr;
				inputStrSplit=inputStr.Split(".");
				if(inputStrSplit.Length==2)
				{
					outputStr=Convert.ToString(Convert.ToInt32(inputStrSplit[0],inputBaseInt),outputBaseInt)+".";
					if(inputBaseInt==10)
					{
						double runDou=Convert.ToDouble("0."+inputStrSplit[1]);
						for (int cs=0;cs<10;cs++)//输出小数次数，相当于保留几位小数(10位小数)
						{
							runDou*=outputBaseInt;
							int num=0;string numStr="";
							while(runDou>=1)
							{
								num+=1;
								runDou-=1;
							}
							if(num>=10)
							{
								switch(num)
								{
									case 10:numStr="a";break;
									case 11:numStr="b";break;
									case 12:numStr="c";break;
									case 13:numStr="d";break;
									case 14:numStr="e";break;
									case 15:numStr="f";break;
								}
							}
							else{numStr=num.ToString();}
							outputStr+=numStr;
							if(runDou==0){break;}
						}
						return outputStr;
					}
					else if(outputBaseInt==10)
					{
						double runDou=0.0;
						for (int i=0;i<inputStrSplit[1].Length;i++)
						{
							runDou+=Convert.ToInt32(inputStrSplit[1].Substring(i,1),inputBaseInt) * Math.Pow(inputBaseInt,-1-i);							
						}
						outputStr+=runDou.ToString().Split(".")[1];
						return outputStr;
					}
				}
				else
				{}
			}
			else
			{
				return Convert.ToString(Convert.ToInt32(inputStr,inputBaseInt),outputBaseInt);
			}
			return "";
		}
	}
}
