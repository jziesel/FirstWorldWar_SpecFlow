Feature: PopularFeatures
	Testing the 'Popular Features' links from the Home Page

@mytag
Scenario: Popular Features - Trench Warfare
	Given the Firefox Webdriver is launched
	And the First World War Home page is loaded
	When the user selects the Trench Warfare link
	Then the user is taken to the Feature Articles - Life in the Trenches page

@mytag
Scenario Outline: Popular Features - Collection
	Given the Firefox Webdriver is launched
	And the First World War Home page is loaded
	When the user clicks the current <link>
	Then the user is taken to the specific <featuredArticle>
	Examples: 
	| link					| featuredArticle                 |
	| How It Began			| The Causes of World War One     |
	| The Christmas Truce	| The Christmas Truce             |
	| Propaganda Posters	| Introduction                    |
	| The July Crisis		| The July Crisis                 |
	| Machine Guns			| Machine Guns                    |
	| Battle of Passchendaele | The Third Battle of Ypres, 1917 |
	| Poison Gas			| Poison Gas                      |
	| Trench Warfare		| Life in the Trenches            |
