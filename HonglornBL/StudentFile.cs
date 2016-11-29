using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using HonglornBL.Models.Entities;

namespace HonglornBL {
  abstract class StudentFile : IEnumerable<Student> {
    IEnumerable<Student> Students { get; }

    protected StudentFile(string filePath) {
      FileInfo file = new FileInfo(filePath);

      if (!file.Exists) {
        throw new ArgumentException("A file with the given path does not exist.", nameof(filePath));
      }
    }

    public IEnumerator<Student> GetEnumerator() {
      return Students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }
  }
}