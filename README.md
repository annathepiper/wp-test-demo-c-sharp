# wp-test-demo-c-sharp

Project to experiment with C#, as part of my 2019 job search for SDET positions.

This suite of test cases runs against an example Wordpress site. It uses Wordpress REST API endpoints to retrieve data about the test site, and analyzes JSON payloads returned by these endpoints.

Since I have no prior experience with C# (as of March 2019), this project is less "demo" and more "practice". My goal with this project is to get some hands-on experience with C# in case a future position needs me to work with the language.

## Prerequisites
To run this suite, I set up a test Wordpress site using Docker Compose. You can see the [wp-docker-compose.yml file](https://github.com/annathepiper/misc-configs/blob/master/docker-compose.yml) I use to set up the containers on my misc-configs repo.

I also add aliases for wordpress.local and phpmyadmin.local to my hosts file, so that those URLs will work as the automation runs.

The test data I'm using is a copy of one of my [live Wordpress sites](http://angelahighland.info).

The main tool I'm using to do this work is Visual Studio 2017. I've checked in all the files the project generated into this repo, and am using RestSharp to hit the service endpoints.
