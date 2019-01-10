using System;
using System.Collections.Generic;

namespace DrawOrSurrender
{
    class Story
    {

        private static Random _random = new Random();

        // Base settings

        private string _title = string.Empty;
        private string _pitch = string.Empty;

        // Flow

        private Stack<Chapter> _chapters = new Stack<Chapter>();
        private Stack<Chapter> _discard = new Stack<Chapter>();

        private int _nbChapters = 0;

        /// <summary>
        /// Makes a new story, with a title and a short pitch.
        /// </summary>
        public Story(string title, string pitch)
        {
            _title = title;
            _pitch = pitch;
        }

        /// <summary>
        /// Displays title and pitch of this story.
        /// </summary>
        public void DisplayStoryInfos()
        {
            Console.WriteLine(_title.ToUpper());
            Console.WriteLine("");
            Console.WriteLine(_pitch);
        }

        /// <summary>
        /// Adds chapter (or multiple chapters) to this story.
        /// </summary>
        /// <param name="chapter">The type of chapter to add to this story.</param>
        /// <param name="nbCopies">The number of times the given chapter should be added.</param>
        public void AddChapter(Chapter chapter, uint nbCopies = 1)
        {
            for(int i = 0; i < nbCopies; i++)
            {
                _chapters.Push(chapter);
                _nbChapters++;
            }
        }

        /// <summary>
        /// Shuffles this story's chapters.
        /// </summary>
        public void Shuffle()
        {
            Shuffle(ref _chapters);
        }

        /// <summary>
        /// Shuffle this story's past or discarded chapters.
        /// </summary>
        public void ShuffleDiscard()
        {
            Shuffle(ref _discard);
        }

        /// <summary>
        /// Shuffles the given chapters pile.
        /// </summary>
        private void Shuffle(ref Stack<Chapter> pile)
        {
            List<Chapter> chaptersAsList = new List<Chapter>();
            foreach (Chapter chapter in _chapters)
            {
                chaptersAsList.Add(chapter);
            }
            chaptersAsList.Shuffle();
            pile = chaptersAsList.ToStackList();
        }

        /// <summary>
        /// Picks the next chapter of the story.
        /// </summary>
        /// <param name="isDiscarded">If true, the found chapter is moved to the top of the discard pile.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        public Chapter PickNextChapter(bool isDiscarded)
        {
            return PickFirstOf(_chapters, _discard, isDiscarded);
        }

        /// <summary>
        /// Picks the chapter on the top of the discard pile.
        /// </summary>
        /// <param name="isMovedBackToStory">If true, moves the found chapter on the top of the story pile.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        public Chapter PickFirstChapterFromDiscard(bool isMovedBackToStory)
        {
            return PickFirstOf(_discard, _chapters, isMovedBackToStory);
        }

        /// <summary>
        /// Picks the first chapter of the given fromList.
        /// </summary>
        /// <param name="fromList">The list where to pick the chapter.</param>
        /// <param name="toList">The possible target of the picked chapter.</param>
        /// <param name="isMoved">If true, the found chapter is moved from fromList to the top of toList.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        private Chapter PickFirstOf(Stack<Chapter> fromList, Stack<Chapter> toList, bool isMoved)
        {
            if(fromList.Count > 0)
            {
                if(isMoved)
                {
                    Chapter chapter = fromList.Pop();
                    toList.Push(chapter);
                    return chapter;
                }
                else
                {
                    return fromList.Peek();
                }
            }

            return null;
        }

        /// <summary>
        /// Picks a chapter with the given title in the story pile.
        /// </summary>
        /// <param name="chapterTitle">The title of the chapter to pick.</param>
        /// <param name="isDiscarded">If true, the found chapter is moved to the top of the discard pile.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        public Chapter PickChapterByTitle(string chapterTitle, bool isDiscarded)
        {
            return PickChapterByTitle(chapterTitle, ref _chapters, _discard, isDiscarded);
        }

        /// <summary>
        /// Picks all chapters with the given title in the story pile.
        /// </summary>
        /// <param name="chapterTitle">The title of the chapters to pick.</param>
        /// <param name="isDiscarded">If true, the found chapters are moved to the top of the discard pile.</param>
        /// <returns>Returns the found chapters, otherwise an emty array.</returns>
        public Chapter[] PickAllChaptersByTitle(string chapterTitle, bool isDiscarded)
        {
            return PickAllChaptersByTitle(chapterTitle, ref _chapters, _discard, isDiscarded);
        }

        /// <summary>
        /// Picks a chapter with the given title in the discard pile.
        /// </summary>
        /// <param name="chapterTitle">The title of the chapter to pick.</param>
        /// <param name="isMovedBackToStory">If true, moves the found chapter on the top of the story pile.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        public Chapter PickChapterByTitleFromDiscard(string chapterTitle, bool isMovedBackToStory)
        {
            return PickChapterByTitle(chapterTitle, ref _discard, _chapters, isMovedBackToStory);
        }

        /// <summary>
        /// Picks all chapters with the given title in the discard pile.
        /// </summary>
        /// <param name="chapterTitle">The title of the chapters to pick.</param>
        /// <param name="isMovedBackToStory">If true, moves the found chapters to the top of the story pile.</param>
        /// <returns>Returns the found chapters, otherwise null.</returns>
        public Chapter[] PickAllChaptersByTitleFromDiscard(string chapterTitle, bool isMovedBackToStory)
        {
            return PickAllChaptersByTitle(chapterTitle, ref _chapters, _discard, isMovedBackToStory);
        }

        /// <summary>
        /// Picks a chapter with the given title in the given fromList.
        /// </summary>
        /// <param name="chapterTitle">The title of the chapter to pick.</param>
        /// <param name="fromList">The list where to find the chapter.</param>
        /// <param name="toList">The possible target of the picked chapter.</param>
        /// <param name="isMoved">If true, the found chapter is moved from fromList to the top of toList.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        private Chapter PickChapterByTitle(string chapterTitle, ref Stack<Chapter> fromList, Stack<Chapter> toList, bool isMoved)
        {
            // Convert stack to list
            List<Chapter> chapters = new List<Chapter>();
            foreach (Chapter chapter in fromList)
            {
                chapters.Add(chapter);
            }

            // Get the index of the chapter with the given title.
            int chapterIndex = -1;
            for(int i = 0; i < chapters.Count; i++)
            {
                if(chapters[i].title == chapterTitle)
                {
                    chapterIndex = i;
                    break;
                }
            }

            return PickChapterAt(chapterIndex, ref fromList, toList, isMoved);
        }

        /// <summary>
        /// Picks all chapters with the given title in the given fromList.
        /// </summary>
        /// <param name="chapterTitle">The title of the chapters to pick.</param>
        /// <param name="fromList">The list where to find the chapters.</param>
        /// <param name="toList">The possible target of the picked chapters.</param>
        /// <param name="isMoved">If true, the found chapters are moved from fromList to the top of toList.</param>
        /// <returns>Returns the found chapters, otherwise an emty array.</returns>
        private Chapter[] PickAllChaptersByTitle(string chapterTitle, ref Stack<Chapter> fromList, Stack<Chapter> toList, bool areMoved)
        {
            // Convert stack to list
            List<Chapter> chapters = new List<Chapter>();
            foreach (Chapter chapter in fromList)
            {
                chapters.Add(chapter);
            }

            // Get the index of the chapters with the given title.
            List<int> chapterIndexes = new List<int>();
            for(int i = 0; i < chapters.Count; i++)
            {
                if(chapters[i].title == chapterTitle)
                {
                    chapterIndexes.Add(i);
                }
            }

            // Store all matching chapters
            List<Chapter> foundChapters = new List<Chapter>();
            for(int i = chapters.Count - 1; i >= 0; i--)
            {
                Chapter chapter = chapters[i];
                if(areMoved)
                {
                    chapters.RemoveAt(i);
                    toList.Push(chapter);
                }
            }
            fromList = chapters.ToStackList();

            return foundChapters.ToArray();
        }

        /// <summary>
        /// Picks a chapter at the given index in the given fromList.
        /// </summary>
        /// <param name="index">The index of the chapter to pick.</param>
        /// <param name="fromList">The list where to find the chapter.</param>
        /// <param name="toList">The possible target of the picked chapter.</param>
        /// <param name="isMoved">If true, the found chapter is moved from fromList to the top of toList.</param>
        /// <returns>Returns the found chapter, otherwise null.</returns>
        private Chapter PickChapterAt(int index, ref Stack<Chapter> fromList, Stack<Chapter> toList, bool isMoved)
        {
            // Convert stack to list
            List<Chapter> chapters = new List<Chapter>();
            foreach(Chapter chapter in chapters)
            {
                chapters.Add(chapter);
            }

            // If the given index is in range
            if(index >= 0 && index < fromList.Count)
            {
                // Remove the chapter at the given index.
                Chapter chapter = chapters[index];
                if(isMoved)
                {
                    chapters.RemoveAt(index);
                    toList.Push(chapter);
                }
                fromList = chapters.ToStackList();

                return chapter;
            }

            return null;
        }

        public int completionPercentage
        {
            get { return ((_nbChapters - remainingChapters) * 100 / _nbChapters); }
        }

        public int remainingChapters
        {
            get { return _chapters.Count; }
        }

        public int countDiscardedChapters
        {
            get { return _discard.Count; }
        }

    }
}
