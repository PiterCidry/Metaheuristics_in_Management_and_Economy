### Function to optimize
optimizer <- function(x){
  x^(2)*sin(15*x*pi)+1
}

reverse.optimizer <- function(x){
  -x^(2)*sin(15*x*pi)+1
}

### Function plot
curve(optimizer, from = -1, to = 2, n = 1000, col = "red", xlab = "x", 
      ylab = "y", main = "Optimized function plot")

### Full review, Random Search, Hill Climbing, Tabu Search
library(readxl)
results_fr <- read_excel("CSharpResults.xlsx",
                         sheet = "FullReview")
results_rs <- read_excel("CSharpResults.xlsx",
                         sheet = "RandomSearch")
results_hc <- read_excel("CSharpResults.xlsx",
                         sheet = "HillClimbing")
results_ts <- read_excel("CSharpResults.xlsx",
                         sheet = "TabuSearch")

### Simulated annealing
library(optimization)
library(dplyr)
library(tictoc)
options(digits = 7)

set.seed(69)
temperatureReduction <- c(0.01, 0.02, 0.05, 0.1, 0.2, 0.3, 
                          0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 0.95, 0.99)
results_sa <- matrix(data = NA, nrow = length(temperatureReduction), 
                     ncol = 4)
tic.clearlog()
for(i in 1:length(temperatureReduction)){
  tic()
  results_sa[i, 1] <- temperatureReduction[i]
  temp <- optim_sa(fun = optimizer,
                     start = -1,
                     maximization = TRUE,
                     lower = -1,
                     upper = 2,
                     trace = TRUE,
                     control = list(
                       t0 = 100,
                       nlimit = 50,
                       r = temperatureReduction[i]
                     ))
  results_sa[i, 2] <- temp$par
  results_sa[i, 3] <- optimizer(temp$par)
  toc(log = TRUE, quiet = TRUE)
}
results_sa[, 4] <- unlist(tic.log(format = TRUE))
results_sa <- results_sa %>% as.data.frame()
colnames(results_sa) <- c("Temp. red.", "Best X", "Best Y", "Time")

### Genetic algorithm
library(GA)
options(digits = 7)
set.seed(592)

populationSize <- c(5, 10, 20, 30, 50, 75, 100, 200, 500, 1000)
results_ga <- matrix(data = NA, nrow = length(populationSize), ncol = 4)
tic.clearlog()
for(i in 1:length(populationSize)){
  tic()
  results_ga[i, 1] <- populationSize[i]
  temp <- ga(type = "real-valued",
             fitness = optimizer,
             min = -1,
             max = 2,
             nBits = 2,
             pmutation = 0.05,
             popSize = populationSize[i],
             monitor = F)
  results_ga[i, 2] <- temp@solution
  results_ga[i, 3] <- temp@fitnessValue
  toc(log = TRUE, quiet = TRUE)
}
results_ga[, 4] <- unlist(tic.log(format = TRUE))
results_ga <- results_ga %>% as.data.frame()
colnames(results_ga) <- c("Pop. Size", "Best X", "Best Y", "Time")