# Dough-Joe
#### 6002CEM Mobile App Development Coursework

## Overview

Many students struggle to balance limited student loan or part-time work income with the increasing costs of rent, education, food, and other necessities. Dough-Joe aims to provide a resource for better financial literacy and a tool by which users can better plan and manage their expenses. This empowers users to better control their finances by tracking income and planned budgets alongside visualising this in a clear UI interface.

This is accomplished by providing users the functionality to create and manage their budget, providing details about their income, and budget with categories such as rent, food, etc. The app then visualises this information in a donut-chart and provides statistics for each budget item, and the percentage it makes up of their total income. This functionality helps users better track their expenses, and highlights categories they should aim to reduce spending. Moreover, the landing page for the app gives users access to useful general and student news articles that help keep users informed.

## Background and Motivation

The issue of financial literacy and education has been especially relevant in the last few years following the Covid-19 pandemic. Since then, the UK especially has experienced a period of high inflation that makes the cost of living harder and harder to manage. This impact is felt on students more so, with limited student loans and wages for young people not able to keep up with the cost of living. One method many young people have turned to using to keep up with these rising costs is budgeting and money management, which inspired the development of this app.

## App Features

### Login and Registration
-	Users can register for an account, which uses the supabase sign-up to securely store their details in the cloud database. This service simplifies registration and login using API calls to validate the details in the cloud and authenticate the request
-	The service also sets password requirements and email format constraints. Any errors received from the service are shown clearly to users, otherwise the user signs in successfully and the app goes to the home page.


### Account Details Page & Change Password
-	Shows users their account details in a simple UI. 
-	Provides functionality to change the user’s password, using a current password field to authenticate the request, and a new password field to set the new password in the supabase user table.


### API News Articles
-	Gets news articles from the newsdata.io used by the API service which is displayed in a collection view on the home page, truncates the article title and description to improve UI clarity.
-	Users can choose the article category using buttons at the top of the page.


### Article Page with Link to Browser
-	Opens an article passed as a parameter from the articles page. Shows the full article title and description, as well as a link that opens the full article on the system browser.


### Create Budget
-	Provides a form where a user can add their income and expenses (rent, food, transport, etc).
-	Ensures accurate budgets with input validation (all fields required, positive integers only).
-	Prevents duplicate budgets by checking supabase for an existing value, offering clear error/success messages and redirecting to the budget page on success.


### Budget Page
-	Fetches the users budget stored in the cloud budget table using the database service. If a budget doesn’t exist, an error is displayed, and the user is redirected to the create budget page.
-	If a budget is found, the service passes this information to the page to display the details. The budget is also fed into the MicroCharts package which generates a donut chart visualising the budget categories as slices of the income.
-	Below the chart, each budget category is shown with its respective amount alongside the percentage of the user’s income it makes up, which is colour coded to the value.

### Delete Budget
-	At the bottom of the budget page the user can use the delete button to remove their budget from the supabase database. This uses the database service again to communicate with supabase through another API call, which responds with positive or negative user feedback depending on success.
