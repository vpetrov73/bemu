﻿//------------------------------------------------------------------------------
// <copyright project="BEmu_cpp" file="headers/HistoricalDataRequest/HistoricElementFieldExceptionsArray.h" company="Jordan Robinson">
//     Copyright (c) 2013 Jordan Robinson. All rights reserved.
//
//     The use of this software is governed by the Microsoft Public License
//     which is included with this distribution.
// </copyright>
//------------------------------------------------------------------------------

#pragma once

#include "BloombergTypes/ElementPtr.h"
#include <vector>

namespace BEmu
{
	namespace HistoricalDataRequest
	{
		class HistoricElementFieldExceptions;

		class HistoricElementFieldExceptionsArray : public ElementPtr
		{
			private:
				std::vector< boost::shared_ptr<HistoricElementFieldExceptions> > _exceptions;

			public:
				HistoricElementFieldExceptionsArray(const std::vector<std::string>& badFields);
				~HistoricElementFieldExceptionsArray();

				virtual Name name() const;
				virtual size_t numValues() const;
				virtual size_t numElements() const;
				virtual SchemaElementDefinition elementDefinition() const;
		
				virtual bool isNull() const;
				virtual bool isArray() const;
				virtual bool isComplexType() const;

				virtual boost::shared_ptr<ElementPtr> getValueAsElement(int index) const;

				virtual std::ostream& print(std::ostream& stream, int level = 0, int spacesPerLevel = 4) const;
		};
	}
}