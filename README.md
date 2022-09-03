# S.L.A.G.
## Seung Lee's Animal Gauntlet

#### By _**Seung Lee, Filmer Tolentino, Matt Herbert, Sandra Tena, Alex Shelvin, Ryan DeFea, Garrett Hays**_  

#### _An API-driven battle game._  

---


## Technologies Used

* _C#_
* _.NET_
* _HTML_
* _CSS_
* _Azure_
* _SQL Workbench_
* _MVC_
* _Identity_
* _Entity_


---
## Description

_This is a(n) MVC application/game that allows a user to create a team of animals, each with their own health and attack attributes, and take them into battle against another team. The battle logic and outcomes are housed in a [custom API](https://github.com/leark/TeamWeekAPI.Solution), which is called to produce the results. The game application was built using C# and utilizes Identity for user authorization, Azure for hosting and CSS stylings. Additionally, this application has an [admin portal](https://github.com/a-shevlin/AdminPortal.Solution) that accompanies it and allows an admin full control of all animals and teams._

---
## Setup and Installation Requirements

<details>
<summary><strong>Initial Setup</strong></summary>
<ol>
<li>Copy the git repository url: https://github.com/ftolentino/TeamWeekClient.Solution
<li>Open a terminal and navigate to your Desktop with <strong>cd</strong> command
<li>Run,   
<strong>$ git clone https://github.com/ftolentino/TeamWeekClient.Solution</strong>
<li>In the terminal, navigate into the root directory of the cloned project folder "TeamWeekClient.Solution".
<li>Navigate to the projects root directory, "TeamWeekClient".
<br>
</details>

<details>
<summary><strong>To Run</strong></summary>
Navigate to:  
   <pre>TeamWeekClient.Solution
   └── <strong>TeamWeekClient</strong></pre>

Run ```$ dotnet restore``` in the terminal.<br>
Run ```$ dotnet run``` in the terminal.
</details>
<br>

This program was built using *`Microsoft .NET SDK 5.0.0`*, and may not be compatible with other versions. Cross-version performance is neither implied nor guaranteed, your actual mileage may vary.

---
## Known Bugs

* _Cannot sign in more than one user at a time_
* _Login page scrolling_
* _Misc battle animations_

## License

_MIT_

Copyright (c) 8/25/2022 Seung Lee, Filmer Tolentino, Matt Herbert, Sandra Tena, Alex Shelvin, Ryan DeFea, Garrett Hays