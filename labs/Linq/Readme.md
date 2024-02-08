## Overview

In this lab, we will experiment with Linq queries on a database of movies.

| | |
| --------- | --------------------------- |
| Exercise Folder | Linq |
| Builds On | None |
| Time to complete | 30 minutes

---

The project contains a file *MoviesJson.txt* that contains JSON encoded movie data.  
Each line in the file contains a movie title, genre, year, rating, and cast.
Review the file *MovieDb.cs*.  This class deserializes the data into a list of *Movie* objects.
> Note - the properties of *MoviesJson.txt* are set to copy the file to 
the output folder so that it is in the same directory as the application .exe.

## Lab
1. First, download and unzip the [starter project](/api/user/File/1296)
1. Add the project to your existing solution (right click on the solution and choose *Add/Existing Project*)

In the top-level statements (*Program.cs*) experiment with queries

- How many movies did your favorite movie star appear in?
- What is the oldest movie with your star?
- What is the most recent?
- Did your favorite star appear in any movies with another favorite?
- Create a new list of just G rated movies with just the title, year, and first cast member
- etc...

---

[Solution](https://github.com/chuckmccullough85/ASP.Net8-Course-20486/tree/main/solutions/Linq)

---
