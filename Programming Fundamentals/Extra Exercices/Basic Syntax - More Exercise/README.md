# More Exercise: C# Intro and Basic Syntax

Problems for exercises and homework for the [&quot;C# Fundamentals&quot; course @ SoftUni](https://softuni.bg/trainings/2363/csharp-fundamentals-may-2019)
You can check your solutions in [Judge](https://judge.softuni.bg/Contests/1453/)

1.
## Sort Numbers

Read three real numbers and sort them in descending order. Print each number on a new line.

### Examples

| **Input** | **Output** |
| --- | --- |
| 213 | 321 |
| -213 | 31-2 |
| 002 | 200 |

1.
## English Name of the Last Digit

Write a **method** that returns the **English name** of the last digit of a given number. Write a program that reads an integer and prints the returned value from this method.

### Examples

| **Input** | **Output** |
| --- | --- |
| 512 | two |
| 1 | one |
| 1643 | three |

1.
## Gaming Store

Write a program, whichhelps you buy the games. The **valid games** are the following games in this table:

| **Name** | **Price** |
| --- | --- |
| OutFall 4 | $39.99 |
| CS: OG | $15.99 |
| Zplinter Zell | $19.99 |
| Honored 2 | $59.99 |
| RoverWatch | $29.99 |
| RoverWatch Origins Edition | $39.99 |

On the first line, you will receive your **current balance** – a **floating-point** number in the range **[0.00…5000.00]**.

Until you receive the command &quot; **Game Time**&quot;, you have to keep **buying games**. When a **game** is **bought** , the user&#39;s **balance** decreases by the **price** of the game.

Additionally, the program should obey the following conditions:

- If a game the user is trying to buy is **not present** in the table above, print &quot; **Not Found**&quot; and **read the next line**.
- If at any point, the user has **$0** left, print &quot; **Out of money!**&quot; and **end the program**.
- Alternatively, if the user is trying to buy a game which they **can&#39;t afford** , print &quot; **Too Expensive**&quot; and **read the next line**.
- If the game exists and the player has the money for it, print **&quot;Bought {nameOfGame}&quot;**

When you receive &quot; **Game Time**&quot;, **print** the user&#39;s **remaining money** and **total spent on games** , **rounded** to the **2**** nd **** decimal place**.

### Examples

| **Input** | **Output** |
| --- | --- |
| 120RoverWatchHonored 2Game Time | Bought RoverWatchBought Honored 2Total spent: $89.98. Remaining: $30.02 |
| 19.99Reimen originRoverWatchZplinter ZellGame Time | Not FoundToo ExpensiveBought Zplinter ZellOut of money! |
| 79.99OutFall 4RoverWatch Origins EditionGame Time | Bought OutFall 4Bought RoverWatch Origins EditionTotal spent: $79.98. Remaining: $0.01 |

1.
## Reverse String

Write a program which reverses a string and print it on the console.

### Examples

| **Input** | **Output** |
| --- | --- |
| Hello | olleH |
| SoftUni | inUtfoS |
| 1234 | 4321 |

1.
## Messages

Write a program, which emulates **typing an SMS** , following this guide:

| **1** | **2** abc | **3** def |
| --- | --- | --- |
| **4** ghi | **5** jkl | **6** mno |
| **7** pqrs | **8** tuv | **9** wxyz |
|
 | **0** space |
 |

Following the guide, **2** becomes &quot; **a**&quot;, **22** becomes &quot; **b**&quot; and so on.

### Examples

| **Input** | **Output** |
 | **Input** | **Output** |
 | **Input** | **Output** |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 54433555555666 | hello | 9443399908443377733 | hey there | 76333380633 | meet me |

### Hints

- A native approach would be to just put all the possible combinations of digits in a giant **switch** statement.
- A cleverer approach would be to come up with a **mathematical formula** , which **converts** a **number** to its **alphabet** representation:

| **Digit** | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
|
  - **Index**
 |
  - 0 1 2
 |
  - 3 4 5
 |
  - 6 7 8
 |
  - 9 11 12
 |
  - 13 14 15
 |
  - 16 17 18 19
 |
  - 20 21 22
 |
  - 23 24 25 26
 |
|
  - **Letter**
 |
  - a b c
 |
  - d e f
 |
  - g h i
 |
  - j k l
 |
  - m n o
 |
  - p q r s
 |
  - t u v
 |
  - w x y z
 |

- Let&#39;s take the number **222** ( **c** ) for example. Our algorithm would look like this:
  - Find the **number of digits** the number has &quot;e.g. **222**  **3 digits**&quot;
  - Find the **main digit** of the number &quot;e.g. **222**  **2**&quot;
  - Find the **offset** of the number. To do that, you can use the formula: **(main digit - 2) \* 3**
  - If the main digit is **8 or 9** , we need to **add 1** to the **offset** , since the digits **7** and **9** have **4 letters each**
  - Finally, find the **letter index** (a  0, c  2, etc.). To do that, we can use the following formula: **(offset + digit length - 1)**.
  - After we&#39;ve found the **letter index** , we can just add that to **the ASCII code** of the lowercase letter &quot; **a**&quot; (97)

[![](RackMultipart20210105-4-8cuae_html_4062ce8ea76a185d.png)](http://softuni.foundation/) ![](RackMultipart20210105-4-8cuae_html_9b0988e43f50c79b.gif) ![](RackMultipart20210105-4-8cuae_html_f746d52952cd7e91.gif) ![](RackMultipart20210105-4-8cuae_html_75bb621a2d054d6e.gif) ![](RackMultipart20210105-4-8cuae_html_8e84094ace6df644.gif)

Page 4 of 4

Follow us:

© [Software University Foundation](http://softuni.foundation/). This work is licensed under the [CC-BY-NC-SA](http://creativecommons.org/licenses/by-nc-sa/4.0/) license.

[![](RackMultipart20210105-4-8cuae_html_f3d5179c0d1f53c.png)](http://softuni.bg/)[![](RackMultipart20210105-4-8cuae_html_4b9dbb17ee958b46.png)](http://softuni.foundation/)[![Software University @ Facebook](RackMultipart20210105-4-8cuae_html_94be3df36d913358.png)](http://facebook.com/SoftwareUniversity)[![Software University @ Twitter](RackMultipart20210105-4-8cuae_html_ff9c629b0a21eb6b.png)](http://twitter.com/softunibg)[![Software University @ YouTube](RackMultipart20210105-4-8cuae_html_7db86a748da0e575.png)](http://youtube.com/SoftwareUniversity)[![](RackMultipart20210105-4-8cuae_html_a9d346b26d97741d.png)](http://plus.google.com/+SoftuniBg/)[![](RackMultipart20210105-4-8cuae_html_9758e785eadf0cc.png)](https://www.linkedin.com/school/3529173/)[![Software University @ SlideShare](RackMultipart20210105-4-8cuae_html_4719811fa6babb65.png)](http://slideshare.net/softwareuniversity)[![](RackMultipart20210105-4-8cuae_html_660141fbd6d8d4a8.png)](http://github.com/softuni)[![Software University: Email Us](RackMultipart20210105-4-8cuae_html_d7fa82ab7332f3fa.png)](mailto:university@softuni.bg)

 ![](RackMultipart20210105-4-8cuae_html_3e71ea613f294223.png)