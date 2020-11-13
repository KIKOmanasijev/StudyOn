#!/bin/bash

function main(){
	while getopts "s:d:" opt; do
		case $opt in
			s) source=$OPTARG;;
			d) dest=$OPTARG;;
		esac
	done

	if [[ -z $source || -z $dest ]];
	then
		echo "Error some of the arguments are missing."
	else
		echo "Filtering data, please wait :)"
		./osmfilter $source --keep="leisure=pitch and sport=" | ./osmconvert - --all-to-nodes --csv="@id @lat @lon sport name" --csv-headline --csv-separator="," > $dest
		cat $dest
		# read
	fi

}
main $@
