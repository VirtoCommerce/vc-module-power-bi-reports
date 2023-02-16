# Power BI Reports

## Overview

Power BI Reports module is a powerful analytics tool that allows users to gain valuable insights into their e-commerce operations. With this module, users can connect their Virto Commerce platform data to Microsoft Power BI, which enables them to create interactive and customizable reports and dashboards.

The module provides a range of pre-built report templates and data models, allowing users to easily extract and visualize critical data on sales, customer behavior, inventory, and more. Additionally, users can customize their reports and dashboards by adding or removing data points, adjusting visuals, and defining specific filters and criteria.

With the ability to access real-time data, users can track the performance of their e-commerce store, identify trends and patterns, and make data-driven decisions to optimize their operations. The Virto Commerce Power BI Reports module also allows users to collaborate and share reports with other team members, enabling cross-functional teams to work together and make more informed decisions.

## Key Features
* Connect Virto Commerce Data to Microsoft Power BI: The Reports module enables users to connect their e-commerce data from Virto Commerce to Microsoft Power BI, allowing them to create interactive and customizable reports and dashboards.
* Explore Your Data Using Natural Language Capabilities: The Reports module allows users to explore their data using natural language capabilities, making it easier to extract insights and make data-driven decisions.
* Sales Dashboard: The Reports module provides a pre-built sales dashboard template, allowing users to easily visualize and track their sales performance.
* Sales Analysis: The Reports module provides a pre-built sales analysis report template, allowing users to extract and analyze critical data on their sales performance, including revenue, order volume, and more.

## Getting Started

### Prerequisites:
* Ensure that the system has Power BI Desktop installed.
* Apply SQL scripts from file [Script bi-Orders-view.sql](/src/Sql-Scripts/bi-Orders-view.sql) on Virto Commerce database to create BI Views which are used as a Data Source.
* Verify that the custom connection string is correctly configured and that the SQL Server and database are accessible from the system where the report will be deployed.

### Publish Power BI Report
* Open the [ECommerce-Sales-Report.pbix](/src/Power-BI-Files/ECommerce-Sales-Report.pbix) file in Power BI Desktop and check that it loads the data correctly.
* Publish the report to Power BI Service using the "Publish" button on the "Home" tab of the Power BI Desktop ribbon.
* Set up data refresh options for the report. Go to the "Datasets" page and click on the ellipsis (...) next to the dataset that corresponds to the report data source. Select "Schedule Refresh" and configure the refresh settings as needed.
* Ensure that the you have appropriate access to the report and its underlying data sources.
* Share the report with the System Administrator, assign them to a role with appropriate permissions, or grant them access to the SQL Server database if necessary.
* Keep Power BI Reports Url. 

### Setup Virto Commerce Module
* In Virto Commerce, go to the "Setting", "Power BI Reports", "General" and setup "Power BI Reports Url".
* Virto Commerce uses this url for redirect when manager selects Reports in the Apps menu.

![](/docs/media/powerbi-settings.png)

![](/docs/media/powerbi-apps-menu.png)

### Screenshots

![Sales Dashboard](/docs/media/sales-dashboard.png)

![Sales Analyze](/docs/media/sales-analyze.png)

![Smart Report](/docs/media/smart-report.png)

## License

Copyright (c) Virto Solutions LTD.  All rights reserved.

Licensed under the Virto Commerce Open Software License (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

<http://virtocommerce.com/opensourcelicense>

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied.
