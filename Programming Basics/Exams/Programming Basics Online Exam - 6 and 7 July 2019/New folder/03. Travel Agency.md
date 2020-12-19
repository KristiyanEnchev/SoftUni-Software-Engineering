
# **Изпит по "Основи на програмирането" – 6 и 7 юли 2019**
## **Задача 3. Туристическа агенция**
Туристическа агенция има нужда от система за изчисляване на дължимата сума при резервация. В зависимост от различните дестинации и различните пакети, цената е различна.

**Цените за ден са следните:**

|**Цена за ден**|**Банско/Боровец**|**Варна/Бургас**|
| :-: | :-: | :-: |
||**с екипировка**|**без екипировка**|**със закуска**|**без закуска**|
||100лв.|80лв|130лв.|100лв.|
|**VIP отстъпка**|10%|5%|12%|7%|
Ако клиентът е заявил престой **повече от 7 дни**, получава **единия ден** безплатно.
### **Вход**
От конзолата се четат **4 реда**:

1. Име на града - текст с възможности ("**Bansko",**  "**Borovets",** "**Varna"** или "**Burgas"**)
1. Вид на пакета - текст с възможности ("**noEquipment",**  "**withEquipment",** "**noBreakfast"** или "**withBreakfast"**)
1. Притежание на VIP отстъпка - текст с възможности  **"yes"** или "**no"**
1. Дни за престой - **цяло число в интервала [1 … 10000]**
### **Изход**
На конзолата се отпечатва **1 ред**:

- Когато потребителят е въвел всички данни правилно, отпечатваме: 
  **"The price is {цената, форматирана до втория знак}lv! Have a nice time!"**
- Ако потребителят е въвел **по-малко от 1 ден** за престой, отпечатваме: 
  **"Days must be positive number!"**
- Когато при въвеждането на **града** или **вида на пакета** се въведат невалидни данни, отпечатваме: **"Invalid input!"**
### **Примерен вход и изход**

|**Вход**|**Изход**|**Коментар**|
| :- | :- | :- |
|<p>Borovets</p><p>noEquipment</p><p>yes</p><p>6</p>|The price is 456.00lv! Have a nice time!|Градът е Боровец, а пакетът е без екипировка, съответно цената за ден е 80лв. Клиентът разполага с VIP пакет, така че цената за ден става 80-80\*0.05=76лв.Резервацията е за 6 дни, следователно крайната цена е 76\*6=456лв.|
|<p>Bansko</p><p>withEquipment</p><p>no</p><p>2</p>|The price is 200.00lv! Have a nice time!||
|<p>Varna</p><p>withBreakfast</p><p>yes</p><p>5</p>|The price is 572.00lv! Have a nice time!||
|<p>Burgas</p><p>noBreakfast</p><p>no</p><p>4</p>|The price is 400.00lv! Have a nice time!||
|<p>Varna</p><p>withBreakfast</p><p>no</p><p>0</p>|Days must be positive number!||
|<p>Gabrovo</p><p>noBreakfast</p><p>no</p><p>3</p>|Invalid input!||





© [Software University Foundation](http://softuni.foundation/). This work is licensed under the [CC-BY-NC-SA](http://creativecommons.org/licenses/by-nc-sa/4.0/) license.

![](03.%20Travel%20Agency.006.png)   ![](03.%20Travel%20Agency.006.png)   ![](03.%20Travel%20Agency.007.png)   ![](03.%20Travel%20Agency.007.png)   ![](03.%20Travel%20Agency.007.png)   ![](03.%20Travel%20Agency.006.png)   ![](03.%20Travel%20Agency.006.png)   ![](03.%20Travel%20Agency.006.png)   ![](03.%20Travel%20Agency.007.png)

Follow us:

Page  PAGE   \\* MERGEFORMAT 2 of  NUMPAGES   \\* MERGEFORMAT 2

Page  PAGE   \\* MERGEFORMAT 2 of  NUMPAGES   \\* MERGEFORMAT 2
