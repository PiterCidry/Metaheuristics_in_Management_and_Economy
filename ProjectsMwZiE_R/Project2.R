GaForTspResults <- read.csv2(
  "~/Studia/Semestr 8/MwZiE/Zadania/Metaheuristics_in_Management_and_Economy/ProjectsMwZiE_C#/ProjectTSP/GaForTspResults.csv")

TSP75 <- read.table("~/Studia/Semestr 8/MwZiE/Zadania/Metaheuristics_in_Management_and_Economy/ProjectsMwZiE_R/TSP75.TXT", 
                    quote="\"", comment.char="")

colnames(TSP75) <- c("X", "Y")

library(dplyr)
library(ggplot2)
options(scipen = 9)

GaForTspResults %>% ggplot(aes("", BestFitness)) + geom_boxplot()
GaForTspResults %>% ggplot(aes("", BestGen)) + geom_boxplot()
GaForTspResults %>% ggplot(aes("", ElapsedMilliseconds)) + geom_boxplot()

GaForTspResults %>% ggplot(aes(BestGen)) + geom_histogram(bins = 20)
GaForTspResults %>% ggplot(aes(BestFitness)) + geom_histogram(bins = 20)

GaForTspResults %>% ggplot(aes(BestGen, BestFitness)) + geom_jitter()

GaForTspResults %>% ggplot(aes(Iterations, ElapsedMilliseconds)) + geom_point() + geom_smooth()
GaForTspResults %>% ggplot(aes(PopulationSize, ElapsedMilliseconds)) + geom_point() + geom_smooth()
GaForTspResults %>% ggplot(aes(Pc, ElapsedMilliseconds)) + geom_point() + geom_smooth()
GaForTspResults %>% ggplot(aes(Pm, ElapsedMilliseconds)) + geom_point() + geom_smooth()
GaForTspResults %>% ggplot(aes(Pi, ElapsedMilliseconds)) + geom_point() + geom_smooth()
GaForTspResults %>% ggplot(aes(BestGen, ElapsedMilliseconds)) + geom_point() + geom_smooth()
GaForTspResults %>% ggplot(aes(BestFitness, ElapsedMilliseconds)) + geom_point() + geom_smooth()