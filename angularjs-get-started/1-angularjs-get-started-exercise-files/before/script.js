// Code goes here

var createWorker = function(){
   
    var task1 = function(){
        console.log("Task 1");
    };

    var task2 = function(){
        console.log("Task 2");
    };

    var worker = {
        job1: task1,
        job2: task2
    };

    return worker;
};

var worker = createWorker();


worker.job1();
worker.job2();
