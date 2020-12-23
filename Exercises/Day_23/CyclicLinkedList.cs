using System.Collections.Generic;

namespace Exercises.Day_23
{
    static class CyclicLinkedList
    {
        public static LinkedListNode<T>? NextOrFirst<T>(this LinkedListNode<T> current) =>
            current.Next ?? current.List?.First;

        public static LinkedListNode<T>? PreviousOrLast<T>(this LinkedListNode<T> current) =>
            current.Previous ?? current.List?.Last;
    }
}