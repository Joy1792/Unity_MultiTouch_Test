﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using TouchScript.InputSources;

namespace TouchScript.Pointers
{

    /// <summary>
    /// A pointer of type <see cref="Pointer.PointerType.Object"/>.
    /// </summary>
    public class ObjectPointer : Pointer
    {
        #region Public properties

        /// <summary>
        /// The Id of the physical object this pointer represents.
        /// </summary>
        public int ObjectId { get; internal set; }

        /// <summary>
        /// The Width of the physical object this pointer represents.
        /// </summary>
        public float Width { get; internal set; }

        /// <summary>
        /// The height of the physical object this pointer represents.
        /// </summary>
        public float Height { get; internal set; }

        /// <summary>
        /// The Rotation of the physical object this pointer represents.
        /// </summary>
        public float Angle { get; internal set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPointer"/> class.
        /// </summary>
        public ObjectPointer(IInputSource input) : base(input)
        {
            Type = PointerType.Object;
        }

        #endregion

        #region Public methods

        /// <inheritdoc />
        public override void CopyFrom(Pointer target)
        {
            base.CopyFrom(target);
            var obj = target as ObjectPointer;
            if (obj == null) return;

            ObjectId = obj.ObjectId;
            Width = obj.Width;
            Height = obj.Height;
            Angle = obj.Angle;
        }

        #endregion

        #region Internal functions

        /// <inheritdoc />
        internal override void INTERNAL_Reset()
        {
            base.INTERNAL_Reset();
            ObjectId = 0;
            Width = 0;
            Height = 0;
            Angle = 0;
        }

        #endregion
    }
}