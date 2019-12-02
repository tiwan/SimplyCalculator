Usually when I have to develope some new feature I start with writing the most straightforward working solutions. When  the business
logic is ensured and I understand it I can start refactoring.
In this scenario the fastest solution would take very small amount of code and it would be not enough to show something useful. I'd go with one method for transform input string into
arrays of numbers and operators and then construct the equalision.

I decided to add some more depth to my solution. That would be the implementation of setting order of mathematical operations. In short program have defined by us order of operators. 
It take the user input and evalute first operation with higest order, then transform this input into new one with already calcualted operation of highest order. Later on its again calcualte 
next in order operation and so on until there is only result.
I was aiming for easy way of adding new operation and changing the priorites - it looks a little naive , why we would like to change the math? but lets assume there is some strange need of thaht.
Just for this case.

Program is working, it calculate in given order. But I wouldn't say that refactorization is complete. There is still some room for improvment, for example
- error handling could be better
- di container is made as simple as possible, in fact it is base of one of many example of containers just for learning procces - it should be replace by one of real world containers, for example: unity or biuld in .net core
- InputParser service could have more refactorisation 
- more unit test




