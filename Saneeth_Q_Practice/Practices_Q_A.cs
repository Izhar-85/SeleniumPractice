using AngleSharp.Common;
using Master_In_Selenium;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Saneeth_Q_Practice;
public class Practices_Q_A
{
    [Test]
    public void Practice_Saneetha()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.hyrtutorials.com/p/add-padding-to-containers.html");
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);
        IWebElement name = driver.FindElement(By.XPath(""));
        Thread.Sleep(3000);
        driver.Quit();
    }

    [Test]
    public void SynchronizationUsing_Implicit_And_Explicit_Wait()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.hyrtutorials.com/p/waits-demo.html");
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        driver.FindElement(By.Id("btn1")).Click();
        Stopwatch sw = Stopwatch.StartNew();
        WebDriverWait wait= new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("txt1")));

        sw.Stop();
        var s= sw.ElapsedMilliseconds;

        driver.FindElement(By.Id("txt1")).SendKeys("Hi Izhar");


        Thread.Sleep(3000);
        driver.Quit();
    }

    [Test]
    public void Remove_the_duplicate_char_from_the_string()
    {
        string str = "Saneetha";

        string s = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (!s.Contains(str[i]))
            {
                s = s + str[i];
            }
            else
            {
                Console.Write(str[i]);
            }
        }

        Console.WriteLine("\n" + s);

        char[] chars = str.ToCharArray();

        int count = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            for (int j = i + 1; j < chars.Length; j++)
            {
                if (chars[i] == chars[j])
                {
                    count++;
                    Console.WriteLine(chars[i]);
                    break;
                }
            }
        }

        Console.WriteLine(count);
    }

    [Test]
    public void Remove_the_duplicate_char_from_the_string_hash_map()
    {
        string str = "Saneetha";
        HashSet<char> set = new HashSet<char>();

        foreach (var item in str)
        {
            set.Add(item);
        }

        foreach (var item in set)
        {
            Console.Write(item);
        }
    }

    [Test]
    public void Revirse_all_the_char_in_the_given_string()
    {
        string str = "Hello Izhar khan Bhai";
        string[] chr = str.Split(' ');
        string rcv = " ";
        for (int i = chr.Length-1; i>=0; i--)
        {
            rcv = rcv + ReverseChar(chr[i]);
        }

        Console.WriteLine(rcv);
    }

    private string ReverseChar(string v)
    {
        string word = " ";
        for (int i = v.Length-1; i >=0; i--)
        {
            word = word + v[i];
        }

        return word;
    }

    [Test]
    public void To_Separate_Digits_Letters_And_Special_Characters_from_a_given_string()
    {
        string str = "sanee@123+th";
        string DigitPattern = @"\d+";
        string AlphaPattern = @"[a-zA-Z]+";
        string spclCharPattern = @"\W+";

        MatchCollection match1 =  Regex.Matches(str, DigitPattern);
        foreach (Match item in match1)
        {
            Console.WriteLine("Digits:"+ item.Value);
        }

        MatchCollection match2 = Regex.Matches(str, AlphaPattern);
        foreach (Match item in match2)
        {
            Console.WriteLine("AlphaChar:"+item.Value);
        }

        MatchCollection match3 = Regex.Matches(str, spclCharPattern);
        foreach (Match item in match3)
        {
            Console.WriteLine("SpecialChar:"+item.Value);
        }

    }

    [Test]
    public void Find_the_largest_number_in_the_array()
    {
        int[] arr = { 100, 25, 2, 1, 20, 70 };

        int max = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        Console.WriteLine(max);
    }

    [Test]
    public void Find_the_second_largest_number_in_the_array()
    {
        int[] arr = { 50, 25, 2, 1, 90 };

        int largest = 0;
        int second_largest = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > largest)
            {
                second_largest = largest;
                largest = arr[i];
            }
            else if (arr[i]> second_largest)
            {
                second_largest = arr[i];
            }
        }
        Console.WriteLine("Largest is :" + largest);
        Console.WriteLine("Second Largest is :" + second_largest);
    }

    [Test]
    public void Sort_the_Array_in_Ascending_order()
    {
        int[] arr = new int[] { 10, 5, 3, 18, 2, 50, 40, 22, 7 };

        int temp;

        for (int i = 0; i < arr.Length-1; i++)
        {
            for (int j = i+1; j< arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {  
                    temp= arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        foreach (int i in arr)
        {
            Console.Write(" "+ i);
        }
    }
    [Test]
   public void  WAP_to_Separate_Digits_Letters_and_Special_Characters_from_a_given_string()
    {
        string str = "Izhar@&!#1234*%";

        string digit = "";
        string chr = "";
        string splsymble = "";

        for (int i = 0;i < str.Length;i++)
        {
            if (char.IsDigit(str[i]))
            {
                digit = digit + str[i];
            }
            if ((str[i]>='A' && str[i]<='Z') || (str[i]>='a' && str[i]<='z'))
            {
                chr= chr + str[i];
            }
            else
            {
                splsymble = splsymble + str[i];
            }
        }
        Console.WriteLine("Digit:"+ digit);
        Console.WriteLine("Character:"+ chr);
        Console.WriteLine("Splecial-Symbal:"+ splsymble);
    }
    [Test]
    public void Check_wether_the_number_is_pelindrom_or_not()
    {
        int n = 1221;
        int r, sum = 0;
        int temp = n;
        while (n > 0)
        {
            r = n % 10;
            sum = (sum * 10) + r;
            n = n / 10;
        }
        if (temp == sum)
            Console.Write("Number is Palindrome.");
        else
            Console.Write("Number is not Palindrome");
    }
    [Test]
    public void Check_the_number_is_prime_or_not()
    {
        int number = 5;
        int m = number / 2;
        int flag = 0;
        for (int i = 2; i <= m; i++)
        {
           if( number% i==0)
            {
                Console.WriteLine("Number is not Prime");
                flag = 1;
                break;
            }
        }
        if(flag == 0)
        {
            Console.WriteLine("Number is Prime");
        }      
    }

    [Test]
    public void Decending_order_in_dictionary()
    {
       Dictionary<string, int> dict = new Dictionary<string, int>
       {
       {"iPhone 11",700},
       {"Galaxy S23",650},
       {"Pixel 4",899},
       {"iPhone 8",284}
       };

       var order_dict= dict.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key, x=>x.Value);
        foreach (var item in order_dict)
        {
            Console.WriteLine(item.Value);
        }
    }

    [Test]
    public void Shift_all_positive_into_left_side_AND_all_negative_into_right_side()
    {
        var n = new[] { 20, -10, -23, 10, -15, 50, 70 };

        int temp;

        for (int i = 0; i < n.Length; i++)
        {
            for(int j = i+1; j<n.Length;j++)
            {
                if (n[j]>0 && n[i]<0)
                {
                    temp = n[i];
                    n[i] = n[j];
                    n[j] = temp;
                }          
            }
        }
        foreach (var item in n)
        {
            Console.Write(item + " ");
        }
    }

    [Test]
    public void Shift_all_Odd_into_front_side_AND_all_Even_into_right_side()
    {
        var n = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        int temp;

        for (int i = 0; i < n.Length; i++)
        {
            for (int j = i + 1; j < n.Length; j++)
            {
                if (n[i]%2 == 0 && n[j]%2!=0)
                {
                    temp = n[i];
                    n[i] = n[j];
                    n[j] = temp;
                }
            }
        }
        foreach (var item in n)
        {
            Console.Write(item + " ");
        }
    }

    [Test]

    public void Reverse_alternative_word_of_given_string()
    {
        string str = "selenium cypress playwrite webdriverio";

        string[] chr = str.Split(' ');

        int i= 1;
        while(i < chr.Length)
        {
            Console.Write(chr[i - 1] +" ");
            reverseTheWord(chr[i]);
            i += 2;
        }
    }

    private void reverseTheWord( string v)
    {
        for(int i = v.Length-1; i>= 0; i--)
        {
            Console.Write(v[i]);
        }
        Console.Write(" ");
    }

    [Test]
    public void Reverse_the_vowels_in_each_word_of_given_string()
    {
        string input = "same hello dame";
        Console.WriteLine("Original String: " + input);

        string result = ReverseVowelsInWords(input);

        Console.WriteLine("Processed String: " + result);
    }
    public string ReverseVowelsInWords(string input)
    {
        string vowels = "aeiouAEIOU";
        return string.Join(" ", input.Split(' ').Select(word =>
        {
            char[] chars = word.ToCharArray();
            int left = 0, right = word.Length - 1;

            while (left < right)
            {
                if (!vowels.Contains(chars[left])) 
                    left++;
                else if (!vowels.Contains(chars[right]))
                    right--;
                else
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;

                    left++;
                    right--;
                }
            }

            return new string(chars);
        }));
    }

    [Test]
    public void print_the_first_non_repeating_char_in_given_string()
    {
        string str = "sillyspiders";
    
        Dictionary<char, int> chrcount = new Dictionary<char, int>();

        foreach (char ch in str)
        {
            if (chrcount.ContainsKey(ch))
            {
                chrcount[ch]++;
            }  
            else
            {
                chrcount[ch] = 1;
            }      
        }
        //first occurence
        foreach (var ch in chrcount)
        {
            if(ch.Value==1)
            {
                Console.WriteLine(ch.Key);
                break;
            }
        }
    }

    [Test]
    public void rotate_the_array()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        int rotations = 2;
        int n = array.Length;
       // rotations %= n; // Handle cases where rotations > n
        Reverse(array, 0, n - 1);
        Reverse(array, 0, rotations - 1);
        Reverse(array, rotations, n - 1);
        Console.WriteLine("Array After Right Rotation: " + string.Join(", ", array));
    }
    static void Reverse(int[] array, int start, int end)
    {
        while (start < end)
        {
            int temp = array[start];
            array[start] = array[end];
            array[end] = temp;
            start++;
            end--;
        }
    }

    [Test]
    public void Linq_to_Object_Operation()
    {
        List<Student> std = new List<Student>()
        {
          new Student() {Id=1, Name="Izhar Khan", Class= 10},
          new Student() {Id=1, Name="Ikrar Khan", Class= 12},
          new Student() {Id=1, Name="Amit", Class= 11},
          new Student() {Id=1, Name="Sabir", Class= 9},
        };
        List<string> words = new List<string>{ "elderberry", "date", "apple", "banana", "cherry"};
        var len = words.OrderByDescending(x=>x);
        foreach (var l in len)
        {
            Console.WriteLine(l);
        }

        //List<int> ints = new List<int>() { 10, 20, 30, 40, 50 };
        //var filterInts = ints.LastOrDefault(x => x < 45);
        //Console.WriteLine(filterInts);

        //var different = std.Where(s => s.Name.EndsWith("r")).ToList();
        //foreach (var s in different)
        //{
        //    Console.WriteLine(s.Name);
        //}
    }
}

