
# **Изпит по "Основи на програмирането" – 6 и 7 юли 2019**
## **Задача 6. Най-силната дума**
` `За Лора думите притежават голяма сила. Тя те моли да измислиш алгоритъм, с който да откриеш коя е "най-силната" дума. До получаване на команда **"End of words"** ще се четат от конзолата **думи**. За да се открие силата на всяка една, трябва да се намери **сборът от ASCII стойностите на символите**, от които се състои думата. Ако **започва с гласна буква** **- 'a', 'e', 'i', 'o', 'u', 'y' (или техните еквивалентни главни букви)**, полученият сбор трябва да се **умножи по дължината на думата**, в противен случай, да се **раздели** на дължината и **да се закръгли до най-близкото цяло число надолу**.
### **Вход**
До получаване на команда **"End of words"** се чете по един ред от конзолата**:**

- **дума – текст** 
### **Изход**
След приключване на програмата се печата на един ред думата с "най-голяма сила":

- **"The most powerful word is {думата с най-голяма сила} - {силата на думата}"** 
### **Примерен вход и изход**

|**Вход**|**Изход**|**Обяснения**|
| :- | :- | :- |
|<p>The</p><p>Most</p><p>Powerful</p><p>Word</p><p>Is</p><p>Experience</p><p>End of words</p>|The most powerful word is Experience - 10320|<p>Първата дума е "The" сумата на ASCII стойностите ѝ е 84 + 104 + 101 = 289. Думата не започва с гласна буква, затова делим сбора на дължината на думата в случая 3. 289 / 3 = 96</p><p>Продължаваме със останалите думи.</p><p>Последната дума е "Experience", сумата не ASCII стойностите ѝ е 1032. Думата започва с гласна буква, затова умножаваме точките по дължината на думата в случая 10.</p><p>1032 \* 10 = 10320</p><p>Получаваме командата "End of words"</p><p>Най-силата дума е "Experience"</p>|
|<p>But</p><p>Some</p><p>People</p><p>Say</p><p>It's</p><p>LOVE</p><p>End of words</p>|The most powerful word is It's - 1372||


© [Software University Foundation](http://softuni.foundation/). This work is licensed under the [CC-BY-NC-SA](http://creativecommons.org/licenses/by-nc-sa/4.0/) license.

![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.004.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)   ![](06.%20The%20Most%20Powerful%20Word.003.png)

Follow us:

Page  PAGE   \\* MERGEFORMAT 1 of  NUMPAGES   \\* MERGEFORMAT 1

Page  PAGE   \\* MERGEFORMAT 1 of  NUMPAGES   \\* MERGEFORMAT 1
