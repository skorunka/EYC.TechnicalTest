# Programming Exercise

Use this exercise as an opportunity to demonstrate your code writing skills. Good use of object-oriented design is encouraged along with effective use of coding standards and best practices. Use of unit tests and solid principles will be a big bonus.

Use the data provided in the next page and apply the rules below on it to generate an invoice for the supplier.

## Rules : Retailer charge calculation

Amount to be charged against a supplier by a retailer is calculated using the following rules. All the charges are applied on the total price of a product (units * unit price)

### Units
- 0 - 1000  :  6% charge
- 1001 - 5000 :  4% charge
- Over 5000 :  3%
- An additional charge is applied for non-UK products. It is charged at a flat rate of 1% 
- Another additional charge is applied for Fresh products. It is charged at a flat rate of 1%

Write a console/MVC application which takes the supplier name as input and displays the invoice. The data on the next page can be used and you can hard-code it or read it from a text file /csv

## Sample Input / Output

**Input**: Supplier 2

**Output**:

|Item      |Total ( units * unit price )|Retailer charge|
|----------|---------:|------:|
|Soft Drink|3000.00   |120.00 |
|Juice     |100,000.00|5000.00|

Explanation for "Juice":
  - Units over 500, so 3% charge 
  - Non-UK, so additional 1% charge
  - Fresh, do another 1% charge on top

**So, total charges is 5% of 100,000, i.e 5000.00**

## Supplier sales data.

**Supplier 1**

|Item|Category|Units|Country|Price|
|----|--------|-----|-------|----:|
|Egg |Fresh   |2,000 |Ireland|1.25 |
|Chicken|Fresh|7,000|Spain|2.20|
|Milk|Processed|9,000|UK|0.79|

**Supplier 2**

|Item|Category|Units|Country|Price|
|----|--------|-----|-------|----:|
|Soft Drink|Processed|3,000|UK|1.00|
|Juice|Fresh|50,000|Spain|2.00|
