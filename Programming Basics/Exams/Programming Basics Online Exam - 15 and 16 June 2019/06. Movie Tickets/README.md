﻿
# **Изпит по "Основи на програмирането" – 15 и 16 юни 2019**
## **Задача 6. Билети за филм**
Трябва да напишете програма, която чете три цели числа  **a1, a2, n** въведени от потребителя и генерира номера за билети, които се състоят от следните **4 символа**:

- Символ 1: символ с **ASCII код** от **а1** до ***а2 - 1***
- Символ 2: цифра от **1** до ***n - 1***
- Символ 3: цифра от **1** до ***n / 2 - 1***
- Символ 4: цифрова репрезентация (ASCII код) на символ 1

След като са изпълнени условията се генерира следния билет:

**"{Символ 1}-{Символ 2}{Символ 3}{Символ  4}"**
### **Вход**
- **a1** – **цяло число** в интервала [65… 89]
- **a2** – **цяло число** в интервала [66… 91]
- **n** – **цяло число** в интервала [1… 10]
### **Изход**
На конзолата трябва да се отпечатат **всички билетни номера, на които** числовата репрезентация на **символ 1** е **нечетна** и **сборът** на **символ 2, символ 3 и символ 4** е **нечетен**.
### **Примерен вход и изход**

|**Вход**|**Изход**|**Обяснения**|
| :-: | :-: | :-: |
|<p>86</p><p>88</p><p>4</p><p></p>|<p>W-1187</p><p>W-3187</p>|<p>**Символ 1** в началото е W(ASCII код 87);** </p><p>**Символ 2**  =  1;</p><p>**Символ 3**  = 1; </p><p>**Символ 4** = 87; <br>Проверяваме дали **Символ 1 e нечетен**.<br>Сборът от **Символ 2**  + **Символ 3 + Символ 4 = 89** също е  нечетен.</p><p>Генериран билет:  **W-1187 и продължаваме с генериране на следващи билети.**</p>|
|<p>71</p><p>74</p><p>6</p><p></p>|<p>G-1171</p><p>G-2271</p><p>G-3171</p><p>G-4271</p><p>G-5171</p><p>I-1173</p><p>I-2273</p><p>I-3173</p><p>I-4273</p><p>I-5173</p>||
|<p>69</p><p>72</p><p>4</p>|<p>E-1169</p><p>E-3169</p><p>G-1171</p><p>G-3171</p>||


© [Software University Foundation](http://softuni.foundation/). This work is licensed under the [CC-BY-NC-SA](http://creativecommons.org/licenses/by-nc-sa/4.0/) license.

![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.004.png)   ![](06.%20Movie%20Tickets.003.png)   ![](06.%20Movie%20Tickets.003.png)

Follow us:

Page  PAGE   \\* MERGEFORMAT 1 of  NUMPAGES   \\* MERGEFORMAT 1

Page  PAGE   \\* MERGEFORMAT 1 of  NUMPAGES   \\* MERGEFORMAT 1
