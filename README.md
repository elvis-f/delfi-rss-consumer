# RSS feed consumer app

A small app with Facebook authorization to consume a RSS feed!

# Features
- Costomizable profile!

![Profile](https://i.imgur.com/teViB7t.png)

- Card based, responsive mobile-friendly UI

![Cards](https://i.imgur.com/332tuHZ.png)

# Installation

Setup a MySQL server for database to run at `localhost:3306`:
(I used a docker `mysql` image)
![image](https://user-images.githubusercontent.com/16985019/233800135-58de3398-a652-476b-89ee-ce7616ddfb70.png)

Add your credidentials to `appsettings.json`

```json
  {
    "ConnectionStrings": {
      "DbConnection": "your-connection-string"
    }
  }
```

Clone this repo, cd into it and run it:

```bash
git clone https://github.com/elvis-f/delfi-rss-consumer
cd delfi-rss-consumer
cd Catchsmart
dotnet run
```
![image](https://user-images.githubusercontent.com/16985019/233800334-2afed696-79ef-4ed0-88ff-831425d5d6a3.png)

Now navigate to `localhost:5115` and check out the app! 
