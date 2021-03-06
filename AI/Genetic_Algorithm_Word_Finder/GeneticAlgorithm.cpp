// GeneticAlgorithm.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <stdlib.h>

int calculateFitness(std::string goal, std::string guessWord)
{
	int fitnessCounter = 0;
	for (int i = 0; i < goal.length(); i++)
	{
		if (goal[i] == guessWord[i])
		{
			fitnessCounter++;
		}
	}

	return fitnessCounter;
}

std::string mutateElement(std::string firstParent, std::string secondParent,int indx)
{
	std::string result = firstParent.substr(0, indx) + secondParent.substr(indx);

	return result;
}

std::string generateRandomString(int length, int start)
{
	std::string str = "abcdefghijklmnopqrstuvwxyz";
	std::string result;

	int pos;
	srand(time_t(start));
	while (result.size() != length) {
		pos = ((rand() % (str.size() - 1)));
		result += str.substr(pos, 1);
	}

	return result;
}

struct Element 
{
	std::string value;
	int fitness;
};

void insertionSort(Element* arr, int n)
{
	int i, j;
	Element key;
	for (i = 1; i < n; i++)
	{
		key = arr[i];
		j = i - 1;

		while (j >= 0 && arr[j].fitness < key.fitness)
		{
			arr[j + 1] = arr[j];
			j = j - 1;
		}
		arr[j + 1] = key;
	}
}


struct Generation
{
	Element* generation;
	int length;

	Generation(int n)
	{
		this->generation = new Element[n];
		this->length = n;
	}

	~Generation()
	{
		delete[] this->generation;
	}

	bool mutateGeneration(std::string goal)
	{
		insertionSort(this->generation, this->length);

		Element* temp = new Element[length];
		int elementsLeft = length / 10;

		for (int i = 0; i < length; i++)
		{
			
			for (int j = elementsLeft; j >= 0; j--)
			{
				if (i >= length) break;
				temp[i].value = mutateElement(this->generation[elementsLeft].value,this->generation[j].value, (rand() % goal.length()) + 1);
				temp[i].fitness = calculateFitness(goal, temp[i].value);
				std::cout << "Word : " << temp[i].value << " " << "Fitness : " << temp[i].fitness << std::endl;
				if (temp[i].fitness == goal.length())
				{
					std::cout << "^^^^^ found ^^^^^" << std::endl;
					return true;
				}
				i++;
				
				temp[i].value = mutateElement(this->generation[j].value, this->generation[elementsLeft].value, (rand() % goal.length()) + 1);
				temp[i].fitness = calculateFitness(goal, temp[i].value);
				std::cout << "Word : " << temp[i].value << " " << "Fitness : " << temp[i].fitness << std::endl;
				if (temp[i].fitness == goal.length())
				{
					std::cout << "^^^^^ found ^^^^^" << std::endl;
					return true;
				}
				i++;
			}
			elementsLeft--;
			i--;
		}

		delete[] this->generation;
		this->generation = temp;
		temp = nullptr;

		return false;
	}

	void generateWords(int wordLength, std::string goal)
	{
		for (int i = 0; i < length; i++)
		{
			this->generation[i].value = generateRandomString(wordLength, i);
			this->generation[i].fitness = calculateFitness(goal, this->generation[i].value);

			std::cout << "Word : " << this->generation[i].value << " " << "Fitness : " << this->generation[i].fitness << std::endl;
		}
	}

	void printGeneration()
	{
		for (int i = 0; i < length; i++)
		{
			std::cout << i + 1 << " " << this->generation[i].value << " " << this->generation[i].fitness;
			std::cout << std::endl;
		}
	}

};

bool isIn(Generation& gen, std::string word)
{
	for (int k = 0; k < gen.length; k++)
	{
		if (gen.generation[k].value == word) 
			return true;
		else
			return false;
	}
}



int main()
{	
	std::string goal = "tsanislav";

	Generation test(1000);

	std::cout << "----------Generation 1 ----------" << std::endl;

	test.generateWords(goal.length(), goal);


	int generationCounter = 1;
	while (!test.mutateGeneration(goal))
	{
		generationCounter++;
		std::cout << "---------- Generation " << generationCounter << "----------" << std::endl;
	}


	system("pause");

    return 0;
}

