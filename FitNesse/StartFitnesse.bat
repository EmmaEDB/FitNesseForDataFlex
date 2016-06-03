@if exist fitnesse-standalone.jar (
    java -jar fitnesse-standalone.jar -p 8081

) else (
    @echo download fitnesse-standalone.jar from http://fitnesse.org/
)
@echo ...
@pause