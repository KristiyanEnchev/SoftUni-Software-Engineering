
# **Изпит по "Основи на програмирането" - 15 и 16 юни 2019**
## **Задача 1. Калкулатор за сериали**
Напишете програма, която **изчислява колко време ще ви отнеме да изгледате всички епизоди на един сериал в минути**. Ще разполагате с **брой сезони**, **брой епизоди на сезон** и **времетраене на един епизод**. Във всеки епизод има **реклами**, които са с продължителност **20% от времето на един епизод**. Също така знаете, че **всеки сезон завършва със специален епизод**, който е **с 10м по-дълъг от обичайното**. 
### **Вход**
От конзолата се четат **4 реда**:

- Име на сериал - **текст**
- Брой сезони – **цяло число** в диапазона **[1… 10]**
- Брой епизоди  – **цяло число** в диапазона **[10… 80]**
- Времетраене н**а обикновен епизод без рекламите** – **реално число** в диапазона **[40.0… 65.0]**
### **Изход**
Да се отпечата на конзолата **времето, необходимо за изглеждане на всички епизоди, закръглено до най-близкото цяло число надолу** в следния формат:

**"Total time needed to watch the {име на сериал} series is {време} minutes."**
### **Примерен вход и изход**

|**Вход**|**Изход**|**Обяснения**|
| :-: | :-: | :-: |
|<p>Lucifer</p><p>3</p><p>18</p><p>55</p>|Total time needed to watch the Lucifer series is 3594 minutes.|<p>Продължителност на реклами за един епизод :</p><p>20% от 55 = 11.0</p><p>Продължителност на епизод с рекламите:</p><p>55 + 11 = 66.0<br>Допълнително време от специалните епизоди:  3\*10 = 30</p><p>Общо време за гледане на сериала:</p><p>66 \* 18 \* 3 + 30 = 3594.0  </p>|
|<p>Game of Thrones</p><p>7</p><p>10</p><p>50</p>|Total time needed to watch the Game of Thrones series is 4270 minutes.||
|<p>Riverdale</p><p>3</p><p>21</p><p>45</p>|Total time needed to watch the Riverdale series is 3432 minutes.||


© [Software University Foundation](http://softuni.foundation/). This work is licensed under the [CC-BY-NC-SA](http://creativecommons.org/licenses/by-nc-sa/4.0/) license.

![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.004.png)   ![](01.%20Series%20Calculator.003.png)   ![](01.%20Series%20Calculator.003.png)

Follow us:

Page  PAGE   \\* MERGEFORMAT 1 of  NUMPAGES   \\* MERGEFORMAT 1

Page  PAGE   \\* MERGEFORMAT 1 of  NUMPAGES   \\* MERGEFORMAT 1
